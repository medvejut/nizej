using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Damage
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageOnTouch : MonoBehaviour
    {
        public LayerMask collisionMask;
        public int damage = 1;

        [MinValue(0f)]
        public float knockbackImpulse;

        [Tooltip("Check collisions with delay. Use WaitForFixedUpdate instead of OnTriggerEnter2D.")]
        public bool executeOnYield;

        [FoldoutGroup("Events")]
        public UnityEvent onHit;

        protected Collider2D _collider;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (executeOnYield)
            {
                StartCoroutine(WaitOnTrigger(other));
                return;
            }

            OnTrigger(other);
        }

        private IEnumerator WaitOnTrigger(Collider2D other)
        {
            yield return new WaitForFixedUpdate();
            OnTrigger(other);
        }

        private void OnTrigger(Collider2D other)
        {
            // Отключенные компоненты всё равно обрабатывают этот колбэк
            if (!isActiveAndEnabled)
                return;
            // Для деактивированного в текущем кадре коллайдере всё равно обрабатывается этот колбэк
            if (!_collider.isActiveAndEnabled)
                return;

            if ((collisionMask & (1 << other.gameObject.layer)) != 0)
            {
                var collidedHealth = other.gameObject.GetComponent<Health>();
                if (collidedHealth != null)
                {
                    var canKnockback = !collidedHealth.Invulnerable && knockbackImpulse > 0f;
                    collidedHealth.Damage(damage);

                    if (canKnockback)
                    {
                        var collidedRigidBody = other.gameObject.GetComponent<Rigidbody2D>();
                        if (collidedRigidBody != null)
                        {
                            var knockbackDirection = _collider.Distance(other).normal;
                            collidedRigidBody.velocity = Vector2.zero;
                            collidedRigidBody.AddForce(knockbackDirection * knockbackImpulse, ForceMode2D.Impulse);
                        }
                    }
                }

                onHit.Invoke();
            }
        }
    }
}