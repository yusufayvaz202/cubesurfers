using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GemUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI _gemCountText;
        [SerializeField] private Image _gemImage;
        [SerializeField] private float _animationDuration = .2f;

        [Header("Settings")]
        private Vector2 _startPosition;

        #region Unity Methods

        private void Awake()
        {
            _startPosition = _gemImage.rectTransform.position;
        }

        #endregion
        
        public void UpdateGemCountText(int gemCount)
        {
            _gemCountText.text = gemCount.ToString();
            
            // for gem UI animation.
            _gemImage.gameObject.SetActive(true);
            _gemImage.rectTransform.DOMove(_gemCountText.rectTransform.position, _animationDuration).OnComplete(ResetAnimation);
        }

        private void ResetAnimation()
        {
            _gemImage.gameObject.SetActive(false);
            _gemImage.rectTransform.position = _startPosition;
        }
    }
}