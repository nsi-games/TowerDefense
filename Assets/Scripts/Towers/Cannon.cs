using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cannon : Tower
    {
        public Transform orb;
        public float lineDelay = .2f;

        private LineRenderer line;

        void Awake()
        {
            line = GetComponent<LineRenderer>();
        }

        protected override void Update()
        {
            base.Update();
            if (currentEnemy == null)
            {
                line.enabled = false;
            }
        }

        public override void Aim(Enemy e)
        {
            orb.LookAt(e.transform);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, orb.position);
            line.SetPosition(2, e.transform.position);
        }
        public override void Attack(Enemy e)
        {
            line.enabled = true;
            e.DealDamage(damage);
            StartCoroutine(DisableLine());
        }

        IEnumerator DisableLine()
        {
            yield return new WaitForSeconds(lineDelay);

            line.enabled = false;
        }
    }
}