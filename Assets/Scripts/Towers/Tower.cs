using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public float damage = 10f;
        public float attackDelay = 1f;

        protected Enemy currentEnemy;

        private float attackTimer = 0f;
        
        protected virtual void Update()
        {
            attackTimer += Time.deltaTime;
            if (currentEnemy)
            {
                Aim(currentEnemy);
                if (attackTimer > attackDelay)
                {
                    Attack(currentEnemy);
                    attackTimer = 0f;
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null &&
               currentEnemy == null)
            {
                currentEnemy = enemy;
            }
        }
        void OnTriggerStay(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();

        }
        void OnTriggerExit(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null &&
               enemy == currentEnemy)
            {
                currentEnemy = null;
            }
        }

        public virtual void Aim(Enemy e) {}
        public virtual void Attack(Enemy e) {}
    }
}