
using System;
using Misc;
using UnityEngine;

namespace Managers
{
    public static class EventManager
    {
        // Event for when a raycast hit.
        public static Action<GameObject> OnIncreaseRaycastHit;
        public static Action<GameObject> OnDecreaseRaycastHit;
        
        //Event for game state is changed
        public static Action<GameState> OnGameStateChanged;
        
        //Event for gem collected
        public static Action OnGemCollected;
    }
}