﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class OrbitCamera : MonoBehaviour
    {
        public Camera attachedCamera;
        public float minYAngle = 30f, maxYAngle = 90f;
        public float ySpeed = 120f, xSpeed = 120f;
        
        void FixedUpdate()
        {
            if (Input.GetMouseButton(1))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");
                Vector3 euler = transform.eulerAngles;
                euler.x -= mouseY * ySpeed * Time.deltaTime;
                euler.y += mouseX * xSpeed * Time.deltaTime;
                euler.x = Mathf.Clamp(euler.x, minYAngle, maxYAngle);
                transform.eulerAngles = euler;
            }
        }
    }
}
