using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Title("Horizontal")]
        public float speed = 2.0f;
        public float smoothTime = 0.05f;

        [Title("Jump")]
        public float jumpForce = 5.0f;
        public float maxJumpTime = 0.5f;

        [TitleGroup("Common")]
        public LayerMask groundLayerMask;
        public float groundCheckDistance = 0.1f;

        [FoldoutGroup("Events")]
        public UnityEvent onJump, onGrounded;

        public float MoveDirection { get; set; }
        public bool Grounded { get; private set; }
        public bool Falling => !Grounded && _rigidbody.velocity.y < 0f;

        private Rigidbody2D _rigidbody;
        private BoxCollider2D _collider;

        private Vector2 _tempVelocity;
        private bool _inJump;
        private float _jumpTimer;

        private void Start()
        {
            _collider = GetComponent<BoxCollider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void RequestJump()
        {
            if (!Grounded)
                return;
            _inJump = true;
            _jumpTimer = maxJumpTime;
            onJump.Invoke();
        }

        public void StopJump()
        {
            _inJump = false;
        }

        private void FixedUpdate()
        {
            var wasGrounded = Grounded;
            Grounded = CheckGrounded();
            if (!wasGrounded && Grounded)
                onGrounded.Invoke();
            
            UpdateHorizontalMovement();
            UpdateVerticalMovement();
        }

        private void UpdateHorizontalMovement()
        {
            var targetVelocity = _rigidbody.velocity;
            targetVelocity.x = MoveDirection * speed;
            _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _tempVelocity, smoothTime);
        }

        private void UpdateVerticalMovement()
        {
            if (_inJump)
            {
                var velocity = _rigidbody.velocity;
                velocity.y = jumpForce;
                _rigidbody.velocity = velocity;

                _jumpTimer -= Time.deltaTime;
                if (_jumpTimer <= 0)
                {
                    _inJump = false;
                }
            }
        }

        private bool CheckGrounded()
        {
            var hit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down,
                groundCheckDistance, groundLayerMask);
            return hit.collider != null;
        }
    }
}