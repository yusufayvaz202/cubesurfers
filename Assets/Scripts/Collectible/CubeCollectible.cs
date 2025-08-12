using Interface;
using Misc;
using UnityEngine;

namespace Collectible
{
    public class CubeCollectible : MonoBehaviour, ICollectible
    {
        [Header("Settings")]
        [SerializeField] private CollectibleType _collectibleType;

        #region Collectible Methods

        public void Collect(Transform baseCubeTransform)
        {
            if (baseCubeTransform == null) return;
            SetSettings(baseCubeTransform);   
        }

        private void SetSettings(Transform parent)
        {
            transform.SetParent(parent);
            
            // Set transform to bottom of the stack
            transform.localPosition = -Vector3.up * transform.localScale.y * (transform.GetSiblingIndex() + 1);
            transform.localRotation = Quaternion.identity;
        }

        #endregion
        
        #region Helper Methods
        
        public CollectibleType GetCollectibleType()
        {
            return _collectibleType;
        }
        
        #endregion
        
    }
}