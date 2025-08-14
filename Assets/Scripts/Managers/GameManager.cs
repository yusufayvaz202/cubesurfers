using Misc;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Singleton")]
        public static GameManager Instance;
        
        [Header("References")]
        [SerializeField] private GemUI _gemUI;
        [SerializeField] private WinLoseUI _winLoseUI;
        
        [Header("Settings")] 
        private GameState _currentGameState;
        private int _gemCount;
        private int _bonusMultiplier;
        
        #region Unity Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            ChangeGameState(GameState.Waiting);
        }

        private void OnEnable()
        {
            EventManager.OnGemCollected += OnGemCollected;
        }

        private void OnDisable()
        {
            EventManager.OnGemCollected -= OnGemCollected;
        }

        #endregion
        
        private void OnGemCollected()
        {
            _gemCount++;
            _gemUI.UpdateGemCountText(_gemCount);
        }

        public void ChangeGameState(GameState newGameState)
        {
            if(_currentGameState == newGameState) return;  
            _currentGameState = newGameState;
            EventManager.OnGameStateChanged?.Invoke(_currentGameState);
            Debug.Log("Current Game State: " + _currentGameState);

            if (newGameState == GameState.Win)
            {
                WinState();
            }
            else if (newGameState == GameState.Lose)
            {
                LoseState();
            }
        }

        public void CalculateBonusMultiplier(int bonusMultiplier)
        {
            _bonusMultiplier = bonusMultiplier;
            _winLoseUI.SetGemMultiplierText(_bonusMultiplier);
            Debug.Log("Bonus: " +_bonusMultiplier);
        }

        public void BonusMultiplierAnimationEnd()
        {
            _gemCount *= _bonusMultiplier;
            _gemUI.UpdateGemCountText(_gemCount);
        }
        
        private void WinState()
        {
            _winLoseUI.OnGameWin();
        }

        private void LoseState()
        {
            _winLoseUI.OnGameOver();
        }
    }
}