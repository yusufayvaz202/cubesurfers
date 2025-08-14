using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinLoseUI : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameObject _blackBackgroundObject;
        [SerializeField] private GameObject _winPopup;
        [SerializeField] private GameObject _losePopup;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _nextLevelButton;

        [Header("Settings")] 
        [SerializeField] private float _animationDuration = 0.3f;
        private Image _blackBackgroundImage;
        private RectTransform _winPopupTransform;
        private RectTransform _losePopupTransform;
        
        [Header("Other Settings")]
        [SerializeField] private TextMeshProUGUI _gemMultiplierText;
        [SerializeField] private RectTransform _gemCountTextTransform;
        
        private void Awake()
        {
            _blackBackgroundImage = _blackBackgroundObject.GetComponent<Image>();
            _winPopupTransform = _winPopup.GetComponent<RectTransform>();
            _losePopupTransform = _losePopup.GetComponent<RectTransform>();

            //TODO: Make Scene Manager
            _restartButton.onClick.AddListener(() => Debug.Log("Restart"));
            _nextLevelButton.onClick.AddListener(() => Debug.Log("Next Level"));
        }

        public void OnGameOver()
        {
            _blackBackgroundObject.SetActive(true);
            _losePopup.SetActive(true);

            _blackBackgroundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
            _losePopupTransform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);
        }

        public void OnGameWin()
        {
            _blackBackgroundObject.SetActive(true);
            _winPopup.SetActive(true);

            _blackBackgroundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
            _winPopupTransform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);

            _gemMultiplierText.gameObject.SetActive(true);
            _gemMultiplierText.rectTransform.DOMove(_gemCountTextTransform.position, 1f).OnComplete(DestroyGemMultiplierText);
        }

        public void SetGemMultiplierText(int multiplier)
        {
            _gemMultiplierText.text = multiplier + "X";
        }

        private void DestroyGemMultiplierText()
        {
            _gemMultiplierText.rectTransform.DOScale(0, .1f).OnComplete(GameManager.Instance.BonusMultiplierAnimationEnd);
        }
    }
}