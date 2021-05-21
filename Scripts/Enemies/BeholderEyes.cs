using Core;
using UnityEngine;

namespace Enemies
{
    public class BeholderEyes : MonoBehaviour
    {
        public LayerMask targetLayerMask;
        
        public GameObject target { get; private set; }
        public bool targetCaptured => target != null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LayerMasks.IsLayerInMask(other.gameObject.layer, targetLayerMask))
            {
                target = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == target)
            {
                target = null;
            }
        }
    }
}