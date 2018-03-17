
namespace state
{ 
    public class AIStateMachine<T>
        {
            public State<T> currentState { get; private set; }
            public T Owner;

            public AIStateMachine(T owner)
            {
                Owner = owner;
                currentState = null;
            }

            public void ChangeState(State<T> newState)
            {
                if (currentState != null)
                {
                    currentState.ExitState(Owner);
                }
                currentState = newState;
                currentState.EnterState(Owner);

            }

            public void Update()
            {
                if (currentState != null)
                {
                    currentState.UpdateState(Owner);
                }
            }
        }


        public abstract class State<T>
        {
            public abstract void EnterState(T owner);
            public abstract void ExitState(T owner);
            public abstract void UpdateState(T owner);
        }
    }
