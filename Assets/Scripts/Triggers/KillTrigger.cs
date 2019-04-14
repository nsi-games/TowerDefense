using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class KillTrigger : MonoBehaviour
    {
        public string objectToDestroy;
        void OnTriggerEnter(Collider other)
        {
            if(other.name.Contains(objectToDestroy))
            {
                Destroy(other.gameObject);
            }    
        }
    }
}