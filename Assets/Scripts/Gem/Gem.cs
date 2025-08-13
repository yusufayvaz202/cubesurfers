using Managers;
using UnityEngine;

namespace Gem
{
    public class Gem : MonoBehaviour
    {
        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {
            // TODO: Can used object pooling and can make some particle effect instead of destroy.
            EventManager.OnGemCollected?.Invoke();
            Destroy(gameObject);
        }

        #endregion
        
        
    }
}