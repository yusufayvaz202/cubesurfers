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

        private float newPositionX;
        
        #region Unity Methods

        private void Awake()
        {
            _inputController = GetComponent<PlayerInputController>();
        }

        private void FixedUpdate()
        {
            SetForwardMovement();
            SetHorizontalMovement();
        }

        #endregion
        
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
        
    }
}