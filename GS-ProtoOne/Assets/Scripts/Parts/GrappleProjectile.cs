using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parts
{
    public class GrappleProjectile : MonoBehaviour
    {
        public float speed = 0.5f;
        public Vector3 relativePosition = Vector3.up * 1.0f + Vector3.right * -0.5f;
        public void Awake()
        {
            transform.position += relativePosition;
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.right*-speed);
        }
    }
}