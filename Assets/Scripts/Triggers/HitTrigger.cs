using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

namespace TowerDefense
{
    public class HitTrigger : MonoBehaviour
    {
        public string hitName;
        public UnityEvent onHit;

        void OnTriggerEnter(Collider other)
        {
            if(other.name.Contains(hitName))
            {
                onHit.Invoke();   
            }
        }
    }
}