using Managers;
using Misc;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputActionAsset _inputActions;
    
        [Header("Input Actions")]
        private InputAction _moveAction;
        
        [Header("Settings")]
        private Vector2 _moveInput;
        private bool _isFirstAction = true;
        public Vector2 MoveInput => _moveInput;

        #region Unity Methods

        private void OnEnable()
        {
            _moveAction = _inputActions.FindAction(Const.InputActions.MOVE);
            _moveAction.started += OnMove;
            _moveAction.performed += OnMove;
            _moveAction.canceled += OnMove;
            _moveAction.Enable();
        }
        
        private void OnDisable()
        {
            _moveAction.started -= OnMove;
            _moveAction.performed -= OnMove;
            _moveAction.canceled -= OnMove;
            _moveAction.Disable();
        }

        #endregion
        
        #region Input Callbacks
        
        private void OnMove(InputAction.CallbackContext context)
        {
            if (_isFirstAction)
            {
                GameManager.Instance.ChangeGameState(GameState.Playing);
                _isFirstAction = false;
            }
            
            _moveInput = context.ReadValue<Vector2>();
        }
        
        #endregion
    }
}
