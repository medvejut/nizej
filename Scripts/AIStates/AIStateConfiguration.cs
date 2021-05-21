using System;
using System.Collections.Generic;

namespace AIStates
{
    public class AIStateConfiguration<TState>
    {
        public readonly List<AIStateTransition<TState>> Transitions;
        public Action EnterHandler;
        public Action ExitHandler;
        public Action UpdateHandler;

        public AIStateConfiguration()
        {
            Transitions = new List<AIStateTransition<TState>>();
        }

        public AIStateConfiguration<TState> Connect(TState state, AIStateTransitionCondition condition)
        {
            Transitions.Add(new AIStateTransition<TState>(condition, state));
            return this;
        }

        public AIStateConfiguration<TState> OnEnter(Action handler)
        {
            EnterHandler = handler;
            return this;
        }

        public AIStateConfiguration<TState> OnExit(Action handler)
        {
            ExitHandler = handler;
            return this;
        }

        public AIStateConfiguration<TState> OnUpdate(Action handler)
        {
            UpdateHandler = handler;
            return this;
        }
    }
}