using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class UIFollowTarget : MonoBehaviour
    {
        public Transform target;
        
        // Update is called once per frame
        void Update()
        {
            Camera cam = Camera.main;
            Vector3 position = cam.WorldToScreenPoint(target.position);
            transform.position = position;
        }
    }
}