using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Electric : Tower
    {
        public Transform orb;
        public float lineDuration = 2f;
        public float electicityRange = 2f;

        private LineRenderer line;
        private Animator anim;
        private List<Enemy> enemies = new List<Enemy>();

        void Awake()
        {
            line = GetComponent<LineRenderer>();
            anim = GetComponent<Animator>();
        }

        protected override void Update()
        {
            base.Update();
            
            if(currentEnemy == null)
            {
                line.enabled = false;
                anim.SetBool("IsFiring", false);
            }
        }

        public override void Aim(Enemy e)
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, orb.position);
            line.SetPosition(2, e.transform.position);
            
            line.positionCount = 3 + enemies.Count;

            int count = 3;
            foreach (var enemy in enemies)
            {
                if (enemy == null)
                    break;
                line.SetPosition(count, enemy.transform.position);
                count++;
            }
        }


        public override void Attack(Enemy e)
        {
            anim.SetBool("IsFiring", true);
            enemies = new List<Enemy>();
            RecursiveAttack(e, enemies);
        }

        public void RecursiveAttack(Enemy attackEnemy, List<Enemy> enemies)
        {
            attackEnemy.DealDamage(damage);            
            enemies.Add(attackEnemy);
                        
            // Perform overlap sphere around current attack enemy
            Collider[] hits = Physics.OverlapSphere(attackEnemy.transform.position, electicityRange);
            foreach (var hit in hits)
            {
                // Is hit an Enemy and hasn't been hit yet
                Enemy hitEnemy = hit.GetComponent<Enemy>();
                if (hitEnemy && !enemies.Contains(hitEnemy))
                {
                    Ray enemyRay = new Ray();
                    enemyRay.direction = hitEnemy.transform.position - attackEnemy.transform.position;
                    enemyRay.origin = attackEnemy.transform.position;
                    RaycastHit hitObject;
                    if (Physics.Raycast(enemyRay, out hitObject))
                    {
                        Enemy en = hitObject.collider.GetComponent<Enemy>();
                        if (en == hitEnemy)
                        {
                            RecursiveAttack(hitEnemy, enemies);
                        }
                    }
                }
            }
        }
    }
}