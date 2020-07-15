using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parts
{
    public class GrappleProjectile : MonoBehaviour
    {
        public float speed = 0.5f;
        public Vector3 relativePosition = Vector3.up * 0.2f + Vector3.right * -0.5f;
        private GameObject _player = null;
        private LineRenderer _lineRenderer;
        private Vector3[] _linePoints;
        private Vector3 _movementDirection = Vector3.zero;
        public Transform endTransform;
        public void Awake()
        {
            transform.position += relativePosition;
            _lineRenderer = GetComponent<LineRenderer>();
            _movementDirection = Vector3.right * -speed;
            endTransform = transform;
        }

        public void SetPlayerReference(GameObject player)
        {
            _player = player;
        }

        private void FixedUpdate()
        {
            transform.Translate(_movementDirection);
            if (_player == null) return;
            _linePoints = new[] {_player.transform.position + relativePosition, endTransform.position};
            _lineRenderer.SetPositions(_linePoints);
        }

        private void OnTriggerEnter(Collider other)
        {
            _movementDirection = Vector3.zero;
            endTransform = other.transform;
        }
    }
}