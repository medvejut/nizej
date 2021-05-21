using UnityEngine;

namespace Core
{
    public class LayerMasks
    {
        public static bool IsLayerInMask(int layer, LayerMask mask)
        {
            return (mask & (1 << layer)) != 0;
        }
    }
}