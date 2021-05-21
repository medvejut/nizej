using Damage;
using Guns;
using Settings;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        [Required, ChildGameObjectsOnly]
        public GameObject punch;
        public float punchKnockback;
        
        private PlayerMovement _movement;
        private Gun _gun;
        private Rigidbody2D _rigidbody;
        private Health _health;

        private InputActions _input;
        private bool _shooting;

        private void Start()
        {
            _health = GetComponent<Health>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _movement = GetComponent<PlayerMovement>();
            _gun = GetComponentInChildren<Gun>();

            _input = new InputActions();
            _input.Gameplay.Enable();
            _input.Gameplay.Jump.performed += context => Action();
            _input.Gameplay.Jump.canceled += context => StopAction();
            
            _gun.onShot.AddListener(StopFalling);
            _movement.onGrounded.AddListener(() => _gun.ReloadAmmo());
            
            _health.onHit.AddListener(OnHit);
            _health.onDeath.AddListener(OnDeath);
        }

        private void Update()
        {
            _movement.MoveDirection = _input.Gameplay.Movement.ReadValue<float>();

            if (_shooting)
            {
                _gun.Shoot();
                if (_gun.Ammo == 0)
                {
                    _shooting = false;
                }
            }

            punch.SetActive(_movement.Falling);
        }

        public void StopFalling()
        {
            var velocity = _rigidbody.velocity;
            if (velocity.y < 0f)
            {
                _rigidbody.velocity = new Vector2(velocity.x, 0f);
            }
        }

        private void Action()
        {
            if (_movement.Grounded)
            {
                _movement.RequestJump();
            }
            else
            {
                _shooting = true;
            }
        }

        private void StopAction()
        {
            _movement.StopJump();
            _shooting = false;
        }

        private void OnHit()
        {
            _movement.StopJump();
        }

        public void OnPunch()
        {
            var velocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector2(velocity.x, punchKnockback);
        }

        private void OnDeath()
        {
            _input.Disable();
        }
    }
}