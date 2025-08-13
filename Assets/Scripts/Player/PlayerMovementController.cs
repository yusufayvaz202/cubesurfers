using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("References")]
        private PlayerInputController _inputController;

        [Header("Settings")]
        [SerializeField] private float _horizontalSpeed = 5f;
        [SerializeField] private float _verticalSpeed = 5f;
        
        #region Unity Methods

        private void Awake()
        {
            _inputController = GetComponent<PlayerInputController>();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        #endregion
        
        private void MovePlayer()
        {
            Vector2 moveInput = _inputController.MoveInput.normalized;
            Vector3 moveVector = new Vector3(moveInput.x * _horizontalSpeed, 0, _verticalSpeed);
            
            transform.Translate( moveVector * Time.fixedDeltaTime);
            //_rigidbody.MovePosition(_rigidbody.position + moveVector * Time.fixedDeltaTime);
        }
        
    }
}