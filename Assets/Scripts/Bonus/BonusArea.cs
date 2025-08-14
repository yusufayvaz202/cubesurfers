using System;
using Managers;
using Misc;
using UnityEngine;

namespace Bonus
{
    public class BonusArea : MonoBehaviour
    {
        [Header("Settings")] private bool _isBonusStarted;

        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {
            if (!_isBonusStarted)
            {
                Debug.Log("OnTriggerEnter : " + other.gameObject.name);
                EventManager.OnBonusAreaEntered?.Invoke();
            }
            else
            {
            }
        }

        private void OnTriggerExit(Collider other)
        {
            GameManager.Instance.ChangeGameState(GameState.Win);
        }

        #endregion
    }
}