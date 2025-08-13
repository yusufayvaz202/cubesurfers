using Managers;
using Misc;
using UnityEngine;

namespace Cube
{
    public class Cube : MonoBehaviour
    {
        [Header("References")] 
        private Collider _collider;

        [Header("Cube Properties")] 
        [SerializeField] private bool _isStacked;
        private Vector3 _rayDirection;
        private float _rayDistance = 0.05f;
        private bool _isHit;

        [Header("Raycast Settings")] 
        private float _rayScale = 1f;
        private bool _isPlaying;
        public LayerMask _layerMask;

        #region Unity Methods

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rayDistance = .5f;
            _rayDirection = Vector3.back;

            if (_isStacked)
            {
                SetDirection();
            }
        }

        private void OnEnable()
        {
            EventManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void FixedUpdate()
        {
            if (!_isPlaying) return;
            SendRaycast();
        }

        private void OnDisable()
        {
            EventManager.OnGameStateChanged -= OnGameStateChanged;
        }

        #endregion

        #region Raycast Methods

        private void SendRaycast()
        {
            _isHit = Physics.BoxCast(_collider.bounds.center + Vector3.up, transform.localScale * _rayScale, _rayDirection, out _, transform.rotation, _rayDistance, _layerMask);
            switch (_isHit)
            {
                case true when !_isStacked:
                    _isStacked = true;
                    SetDirection();
                    SetLayerToDefault();
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

        private void SetLayerToDefault()
        {
            gameObject.layer = 0;
        }

        #endregion

        #region Helper Methods

        private void OnGameStateChanged(GameState currentGameState)
        {
            _isPlaying = currentGameState == GameState.Playing;
        }

        #endregion
       
    }
}