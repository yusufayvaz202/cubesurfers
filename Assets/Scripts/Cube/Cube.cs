using Managers;
using UnityEngine;

namespace Cube
{
    public class Cube : MonoBehaviour
    {
        [Header("References")]
        private Collider _collider;
        
        [Header("Cube Properties")]
        private Vector3 _rayDirection;
        private float _rayDistance;
        private bool _isStacked;
        private bool _isHit;

        [Header("Raycast Settings")]
        RaycastHit _hits;
        private float _rayScale = 1f;
    
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rayDistance = .5f;
            _rayDirection = Vector3.back;
        }

        private void FixedUpdate()
        {
            _isHit = Physics.BoxCast(_collider.bounds.center + Vector3.up, transform.localScale * _rayScale, _rayDirection, out _hits, transform.rotation, _rayDistance);

            switch (_isHit)
            {
                case true when !_isStacked:
                    _isStacked = true;
                    SetDirection();
                    EventManager.OnIncreaseRaycastHit?.Invoke(gameObject);
                    break;
                case true when _isStacked:
                    EventManager.OnDecreaseRaycastHit?.Invoke(gameObject);
                    break;
            }
        }

        private void SetDirection()
        {
            _rayDirection = Vector3.forward;
        }
    
    }
}