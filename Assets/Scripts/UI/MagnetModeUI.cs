using DG.Tweening;
using Managers;
using Misc;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MagnetModeUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image _magnetImage;

        #region Unity Methods

        private void OnEnable()
        {
            EventManager.OnPlayerStateChanged += OnPlayerStateChanged;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerStateChanged -= OnPlayerStateChanged;
        }

        #endregion
        
        private void StartMagnetAnimation()
        {
            _magnetImage.gameObject.SetActive(true);
            _magnetImage.rectTransform.DOShakeAnchorPos(3f, 75f).OnComplete(StopMagnetAnimation);
        }

        private void StopMagnetAnimation()
        {
            _magnetImage.gameObject.SetActive(false);
        }
        
        private void OnPlayerStateChanged(PlayerStates playerState)
        {
            if (playerState == PlayerStates.MagnetMode)
            {
                StartMagnetAnimation();
            }
        }
    }
}