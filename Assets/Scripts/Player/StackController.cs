using System.Collections.Generic;
using DG.Tweening;
using Managers;
using Misc;
using UnityEngine;

namespace Player
{
    public class StackController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private GameObject _lastBlockObject;
        private List<GameObject> _stackObjects = new();
        private bool _isBonusArea;

        #region Unity Methodss

        private void Start()
        {
            _stackObjects.Add(_lastBlockObject);
            UpdateLastBlockObject();
        }

        private void OnEnable()
        {
            EventManager.OnIncreaseRaycastHit += IncreaseNewBlock;
            EventManager.OnDecreaseRaycastHit += DecreaseBlock;
            
            EventManager.OnBonusAreaEntered += OnBonusAreaEntered;
        }
        

        private void OnDisable()
        {
            EventManager.OnIncreaseRaycastHit -= IncreaseNewBlock;
            EventManager.OnDecreaseRaycastHit -= DecreaseBlock;

            EventManager.OnBonusAreaEntered -= OnBonusAreaEntered;
        }

        #endregion

        #region Stack Methods

        private void IncreaseNewBlock(GameObject cube)
        {
            transform.DOMoveY(transform.position.y + 1f, .5f).SetEase(Ease.OutBack);
            cube.transform.position = new Vector3(transform.position.x, _lastBlockObject.transform.position.y - 1f, transform.position.z);
            cube.transform.SetParent(transform);
            
            _stackObjects.Add(cube);
            UpdateLastBlockObject();
        }

        private void DecreaseBlock(GameObject cube)
        {
            cube.transform.parent = null;
            _stackObjects.Remove(cube);
            
            UpdateLastBlockObject();

            if (_isBonusArea)
            {
                if (_stackObjects.Count < 1)
                {
                    // if player in the bonus area you WİN the game.
                    GameManager.Instance.ChangeGameState(GameState.Win);
                }
            }
            else
            {
                if (_stackObjects.Count < 1)
                {
                    // if the stack counter less than 1 and is not bonus area you LOSE the game. 
                    GameManager.Instance.ChangeGameState(GameState.Lose);
                }
            }
        }

        #endregion

        #region Helper Methods

        private void UpdateLastBlockObject()
        {
            if (_stackObjects.Count == 0) return;
            _lastBlockObject = _stackObjects[^1];
        }
         
        private void OnBonusAreaEntered()
        {
            _isBonusArea = true;
            GameManager.Instance.CalculateBonusMultiplier(_stackObjects.Count);
        }

        #endregion
        
    }
}
