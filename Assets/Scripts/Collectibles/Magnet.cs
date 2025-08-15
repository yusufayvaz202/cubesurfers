using Managers;
using Misc;
using UnityEngine;

namespace Collectibles
{
    public class Magnet : MonoBehaviour
    {
        [SerializeField] private float _backTime = 5f;
        
        private void OnTriggerEnter(Collider other)
        {
            EventManager.OnPlayerStateChanged?.Invoke(PlayerStates.MagnetMode);
            Invoke(nameof(BackToNormalMode), _backTime);
        }

        private void BackToNormalMode()
        {
            EventManager.OnPlayerStateChanged?.Invoke(PlayerStates.NormalMode);
        }
    }
}