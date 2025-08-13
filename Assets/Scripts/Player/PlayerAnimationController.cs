using Managers;
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

        private void OnEnable()
        {
            EventManager.OnIncreaseRaycastHit += PlayJumpAnimation;
        }
        
        private void OnDisable()
        {
            EventManager.OnIncreaseRaycastHit -= PlayJumpAnimation;
        }

        #endregion
        
        #region Animation Methods
        
        //TODO: Parameter because the event is unnecessary. refactor it later.
        private void PlayJumpAnimation(GameObject cube)
        {
            _animator.SetTrigger(Const.Animations.JUMP);
        }
        
        #endregion
    }
}