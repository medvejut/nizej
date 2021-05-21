using AIStates;
using Damage;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Health))]
    public class BeholderAI : MonoBehaviour
    {
        private static readonly int Hunt = Animator.StringToHash("Hunt");

        private enum State
        {
            Initial,
            Idle,
            Hunt,
            Dead
        }

        private Health _health;
        private BeholderEyes _eyes;
        private EnemyFly _fly;
        private Animator _animator;

        private AIStateMachine<State> _stateMachine;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _fly = GetComponentInChildren<EnemyFly>();
            _eyes = GetComponentInChildren<BeholderEyes>();
            _health = GetComponent<Health>();

            _fly.enabled = false;

            _stateMachine = new AIStateMachine<State>(State.Initial);

            _stateMachine.Add(State.Initial)
                .Connect(State.Idle, () => true);

            _stateMachine.Add(State.Idle)
                .Connect(State.Hunt, () => _eyes.targetCaptured)
                .Connect(State.Dead, () => _health.Dead);

            _stateMachine.Add(State.Hunt)
                .OnEnter(OnHunt)
                .OnExit(OnHuntExit)
                .Connect(State.Dead, () => _health.Dead);

            _stateMachine.Add(State.Dead);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void OnHunt()
        {
            _fly.target = _eyes.target.transform;
            _fly.enabled = true;
            _animator.SetBool(Hunt, true);
        }

        private void OnHuntExit()
        {
            _fly.enabled = false;
            _animator.SetBool(Hunt, false);
        }
    }
}