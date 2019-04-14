using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Laser : Tower
    {
        public Transform orb;

        private LineRenderer line;
        private Animator anim;
        
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
        }
        public override void Attack(Enemy e)
        {
            e.DealDamage(damage);
            anim.SetBool("IsFiring", true);
        }
    }
}