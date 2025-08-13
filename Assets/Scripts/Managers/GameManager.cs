using Misc;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GemUI _gemUI;
        
        [Header("Settings")] 
        private GameState _currentGameState;
        private int _gemCount;
        
        #region Unity Methods

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

        private void ChangeGameState(GameState newGameState)
        {
            _currentGameState = newGameState;
            EventManager.OnGameStateChanged?.Invoke(_currentGameState);
        }
        
    }
}