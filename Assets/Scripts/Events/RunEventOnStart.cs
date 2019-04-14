using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

namespace TowerDefense
{
    public class RunEventOnStart : MonoBehaviour
    {
        public UnityEvent onStart;

        // Use this for initialization
        void Start()
        {
            onStart.Invoke();
        }
    }
}