using Managers;
using Misc;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("References")]
        private PlayerInputController _inputController;

        [Header("Settings")]
        [SerializeField] private float _horizontalSpeed = 5f;
        [SerializeField] private float _forwardSpeed = 5f;
        [SerializeField] private float _horizontalLimit = 3f;

        private bool _isPlaying;
        private float newPositionX;
        
        #region Unity Methods

        private void Awake()
        {
            _inputController = GetComponent<PlayerInputController>();
        }

        private void OnEnable()
        {
            EventManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void FixedUpdate()
        {
            if(!_isPlaying) return;
            SetForwardMovement();
            SetHorizontalMovement();
        }

        private void OnDisable()
        {
            EventManager.OnGameStateChanged -= OnGameStateChanged;
        }

        #endregion

        #region Movement Methods

        private void SetForwardMovement()
        {
            transform.Translate(Vector3.forward * (_forwardSpeed * Time.fixedDeltaTime));
        }

        private void SetHorizontalMovement()
        {
            newPositionX = transform.position.x + _inputController.MoveInput.x * _horizontalSpeed * Time.fixedDeltaTime;
            newPositionX = Mathf.Clamp(newPositionX, -_horizontalLimit, _horizontalLimit);
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
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