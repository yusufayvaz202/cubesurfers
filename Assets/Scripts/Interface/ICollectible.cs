using UnityEngine;
using Misc;

namespace Interface
{
    public interface ICollectible
    {
        void Collect(Transform baseCubeTransform = null);
        CollectibleType GetCollectibleType();
    }
}