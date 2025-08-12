using Misc;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [Header("References")]
        private Animator _animator;

        #region Unity Methods

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        #endregion
        
        #region Animation Methods
        
        public void PlayJumpAnimation()
        {
            _animator.SetTrigger(Const.Animatons.JUMP);
        }
        
        #endregion
    }
}