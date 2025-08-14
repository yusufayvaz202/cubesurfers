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
            Debug.Log("Collectibles.Magnet entered");
            EventManager.OnPlayerStateChanged?.Invoke(PlayerStates.MagnetMode);
            Invoke(nameof(BackToNormalMode), _backTime);
        }

        private void BackToNormalMode()
        {
            Debug.Log("Collectibles.Magnet exited");
            EventManager.OnPlayerStateChanged?.Invoke(PlayerStates.NormalMode);
        }
    }
}