using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parts
{
    public class GrappleProjectile : MonoBehaviour
    {
        public float speed = 0.5f;
        public Vector3 relativePosition = Vector3.up * 0.3f + Vector3.right * -0.5f;
        public Transform endTransform;
        public float range = 5f;
        private GameObject _player = null;
        private LineRenderer _lineRenderer;
        private Vector3[] _linePoints;
        private Vector3 _movementDirection = Vector3.zero;
        private float _direction = 0; //1 for right, -1 for left
        private int _playerNo;
        private bool _grappleHit = false;

        #region InitialSetup
            public void Awake()
            {
                SetUpTransform();
                _lineRenderer = GetComponent<LineRenderer>();
                _movementDirection = Vector3.forward * speed;
                _grappleHit = false;
            }

            private void SetUpTransform()
            {
                var currentTransform = transform;
                var position = currentTransform.position;
                position += relativePosition;
                currentTransform.position = position;
                endTransform = currentTransform;
            }
            #endregion
        

        public void SetPlayerReference(GameObject player)
        {
            _player = player;
            _playerNo = _player.GetComponent<SetInput>().playerNo;
            _direction = (_playerNo == 1) ? 1 : -1;
        }

        private void FixedUpdate()
        {
            transform.Translate(_movementDirection);
            if (_player == null) return;
            CheckIfWithinRange();
            UpdateGrappleLinePositions();
        }

        private void UpdateGrappleLinePositions()
        {
            _linePoints = new[] {_player.transform.position + relativePosition, endTransform.position};
            _lineRenderer.SetPositions(_linePoints);
        }

        private void CheckIfWithinRange()
        {
            if ((_player.transform.position - endTransform.position).magnitude > range) Destroy(gameObject);
        }

        #region Collision

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ProcessPotentialCollision(other.gameObject);
            }
            else if (other.CompareTag("AbilityObject"))
            {
                Destroy(gameObject);
            }
        }

        private void ProcessPotentialCollision(GameObject player)
        {
            if (CheckCollisionValidity(player)) return;
            GrappleHit(player);
        }

        private void GrappleHit(GameObject player)
        {
            _grappleHit = true;
            SetGrappleEndPoint(player.transform);
            var direction = (_movementDirection.x <= 0) ? 1 : -1;
            player.GetComponent<PlayerMovement>().HitByGrapple(_movementDirection);
            _movementDirection = Vector3.zero;
            Destroy(gameObject, 1.0f);
        }

        private void SetGrappleEndPoint(Transform player)
        {
            var endPoint = new GameObject("grappleEndPoint");
            endPoint.transform.parent = player;
            endPoint.transform.position = player.position + relativePosition;
            endTransform = endPoint.transform;
            Destroy(endPoint, 1.0f);
        }

        private bool CheckCollisionValidity(GameObject player)
        {
            var otherPlayerNo = player.GetComponent<SetInput>().playerNo;
            if (_grappleHit) return true;
            if (otherPlayerNo != _playerNo) return false;
            otherPlayerNo = 0;
            return true;
        }

        #endregion
    }
}