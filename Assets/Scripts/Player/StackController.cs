using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class StackController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]private GameObject _lastBlockObject;
        private List<GameObject> _stackObjects = new();

        #region Unity Methodss

        private void Start()
        {
            _stackObjects.Add(_lastBlockObject);
            UpdateLastBlockObject();
        }

        private void OnEnable()
        {
            Managers.EventManager.OnIncreaseRaycastHit += IncreaseNewBlock;
            Managers.EventManager.OnDecreaseRaycastHit += DecreaseBlock;
        }
        
        private void OnDisable()
        {
            Managers.EventManager.OnIncreaseRaycastHit -= IncreaseNewBlock;
            Managers.EventManager.OnDecreaseRaycastHit -= DecreaseBlock;
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
        }

        #endregion

        #region Helper Methods

        private void UpdateLastBlockObject()
        {
            _lastBlockObject = _stackObjects[^1];
        }

        #endregion
        
    }
}
