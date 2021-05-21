namespace AIStates
{
    public delegate bool AIStateTransitionCondition();

    public class AIStateTransition<TState>
    {
        public readonly AIStateTransitionCondition Condition;
        public readonly TState State;

        public AIStateTransition(AIStateTransitionCondition condition, TState state)
        {
            Condition = condition;
            State = state;
        }
    }
}