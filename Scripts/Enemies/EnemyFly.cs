using Sirenix.OdinInspector;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyFly : MonoBehaviour
    {
        [SceneObjectsOnly]
        public Transform target;

        [HideIf("target")]
        public Vector2 targetPosition;

        public float speed = 10f;
        public float smoothTime = 1f;

        private Rigidbody2D _rigidbody;
        private Vector2 _currentVelocity;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            var direction = (GetTargetPosition() - (Vector2) transform.position).normalized;
            _rigidbody.velocity =
                Vector2.SmoothDamp(_rigidbody.velocity, direction * speed, ref _currentVelocity, smoothTime);
        }

        public Vector2 GetTargetPosition()
        {
            return target ? (Vector2) target.transform.position : targetPosition;
        }
    }
}