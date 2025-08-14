using Managers;
using UnityEngine;

namespace Obstacle
{
    public class WaterObstacle : MonoBehaviour
    {
        [Header("Settings")]
        private bool _isEntered;

        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {
            if (_isEntered) return;
            _isEntered = true;
            EventManager.OnPerformedWater?.Invoke(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!_isEntered) return;
            _isEntered = false;
            EventManager.OnPerformedWater?.Invoke(false);
        }

        #endregion
        
    }
}