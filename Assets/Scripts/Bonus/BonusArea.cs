using Managers;
using Misc;
using UnityEngine;

namespace Bonus
{
    public class BonusArea : MonoBehaviour
    {
        [Header("Settings")] 
        private bool _isBonusStarted;

        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {
            if (!_isBonusStarted)
            {
                _isBonusStarted = true;
                EventManager.OnBonusAreaEntered?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!_isBonusStarted) return;
            GameManager.Instance.ChangeGameState(GameState.Win);
        }

        #endregion
    }
}