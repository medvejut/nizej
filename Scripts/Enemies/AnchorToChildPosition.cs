using Sirenix.OdinInspector;
using UnityEngine;

namespace Enemies
{
    public class AnchorToChildPosition : MonoBehaviour
    {
        [Required, ChildGameObjectsOnly]
        public GameObject child;

        private Vector3 _offset;
        
        private void Start()
        {
            _offset = transform.position - child.transform.position;
        }

        private void Update()
        {
            transform.position = child.transform.position + _offset;
            child.transform.position = transform.position - _offset;
        }

        public void SetChild(GameObject newChild)
        {
            child = newChild;
            _offset = transform.position - child.transform.position;
        }
    }
}