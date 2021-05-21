using UnityEngine;

namespace Guns
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        public float lifeTime = 1f;

        private Rigidbody2D _rigidbody;

        public Vector2 Direction { get; set; } = Vector2.zero;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            if (lifeTime > 0f)
            {
                Destroy(gameObject, lifeTime);
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Direction * speed;
        }
    }
}