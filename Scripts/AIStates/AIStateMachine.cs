using System.Collections.Generic;

namespace AIStates
{
    public class AIStateMachine<TState>
    {
        private readonly Dictionary<TState, AIStateConfiguration<TState>> _states;

        public AIStateMachine(TState initialState)
        {
            State = initialState;
            _states = new Dictionary<TState, AIStateConfiguration<TState>>();
        }

        public TState State { get; private set; }

        public void Update()
        {
            var currentState = _states[State];

            var newState = GetStateFromTransitions();
            if (!State.Equals(newState))
            {
                currentState.ExitHandler?.Invoke();
                
                State = newState;
                currentState = _states[newState];
                currentState.EnterHandler?.Invoke();
            }

            currentState.UpdateHandler?.Invoke();
        }

        private TState GetStateFromTransitions()
        {
            var successTransition = _states[State].Transitions.Find(transition => transition.Condition());
            return successTransition != null ? successTransition.State : State;
        }

        public AIStateConfiguration<TState> Add(TState state)
        {
            var aiState = new AIStateConfiguration<TState>();
            _states.Add(state, aiState);
            return aiState;
        }
    }
}