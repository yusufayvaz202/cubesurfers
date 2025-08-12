using Interface;
using Misc;
using UnityEngine;

namespace Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [Header("Player Scripts References")] 
        private PlayerMovementController _playerMovementController;
        private PlayerAnimationController _playerAnimationController;

        [Header("Other References")]
        [SerializeField] private Transform _baseCubeTransform;

        #region Unity Methods

        private void Awake()
        {
            _playerMovementController = GetComponent<PlayerMovementController>();
            _playerAnimationController = GetComponent<PlayerAnimationController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckTriggers(other);
        }

        #endregion

        private void CheckTriggers(Collider other)
        {
            if (other.TryGetComponent(out ICollectible collectible))
            {
                if (collectible.GetCollectibleType() == CollectibleType.Cube)
                {
                    CubeCollectibleCollected(collectible);
                }
            }
        }

        #region Collectible Methods

        private void CubeCollectibleCollected(ICollectible collectible)
        {
            collectible.Collect(_baseCubeTransform);
            // Set player transform to up and animate jump
            _playerMovementController.SetYPosition(_baseCubeTransform.localScale.y);
            _playerAnimationController.PlayJumpAnimation();
        }

        #endregion
    }
}