
using System;
using UnityEngine;

namespace Managers
{
    public static class EventManager
    {
        // Event for when a raycast hit.
        public static Action<GameObject> OnIncreaseRaycastHit;
        public static Action<GameObject> OnDecreaseRaycastHit;
    }
}