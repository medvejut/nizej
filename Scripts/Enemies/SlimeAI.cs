using System;
using System.Collections;
using AIStates;
using Damage;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(EnemySimpleMovement))]
    public class SlimeAI : MonoBehaviour
    {
        private static readonly int WalkingHash = Animator.StringToHash("Walking");
        
        public Vector2 idleTimeRange = new Vector2(1f, 2f);
        public Vector2 walkTimeRange = new Vector2(2f, 5f);

        private enum State
        {
            Initial,
            Idle,
            Walk,
            Dead
        }

        private EnemySimpleMovement _movement;
        private Animator _animator;
        private Health _health;

        private AIStateMachine<State> _stateMachine;
        private bool _readyToWalk;

        private void Start()
        {
            _health = GetComponent<Health>();
            _movement = GetComponent<EnemySimpleMovement>();
            _animator = GetComponentInChildren<Animator>();
            
            _stateMachine = new AIStateMachine<State>(State.Initial);

            _movement.enabled = false;

            _stateMachine.Add(State.Initial)
                .Connect(State.Idle, () => true);

            _stateMachine.Add(State.Idle)
                .OnEnter(OnIdle)
                .OnExit(StopAllCoroutines)
                .Connect(State.Walk, () => _readyToWalk)
                .Connect(State.Dead, () => _health.Dead);

            _stateMachine.Add(State.Walk)
                .OnEnter(OnWalk)
                .OnExit(OnWalkExit)
                .Connect(State.Idle, () => !_readyToWalk)
                .Connect(State.Dead, () => _health.Dead);

            _stateMachine.Add(State.Dead);
        }

        private void LateUpdate()
        {
            _stateMachine.Update();
        }

        public void Idle()
        {
            _readyToWalk = false;
        }

        private void OnIdle()
        {
            _animator.SetBool(WalkingHash, false);
            StartCoroutine(Idling());
        }

        private IEnumerator Idling()
        {
            yield return new WaitForSeconds(Random.Range(idleTimeRange.x, idleTimeRange.y));
            _readyToWalk = true;
        }

        private void OnWalk()
        {
            _animator.SetBool(WalkingHash, true);
            _movement.enabled = true;
            StartCoroutine(Walking());
        }

        private IEnumerator Walking()
        {
            yield return new WaitForSeconds(Random.Range(walkTimeRange.x, walkTimeRange.y));
            _readyToWalk = false;
        }

        private void OnWalkExit()
        {
            _movement.enabled = false;
            StopAllCoroutines();
        }
    }
}