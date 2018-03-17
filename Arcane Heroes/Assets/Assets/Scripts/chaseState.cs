using state;
using UnityEngine;

public class chaseState : State<baseAI>
{
    private static chaseState instance;

    private chaseState()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public static chaseState Instance
    {
        get
        {
            if (instance == null)
            {
                new chaseState();
            }
            return instance;
        }
    }



    public override void EnterState(baseAI owner)
    {
        Debug.Log("Entering chase");
    }


    public override void ExitState(baseAI owner)
    {
        Debug.Log("Exiting chase");
    }

    public override void UpdateState(baseAI owner)
    {

        if (owner.currentState == (int)baseAI.AIState.idle)
        {
            owner.stateMachine.ChangeState(idleState.Instance);
        }
        if(owner.currentState == (int)baseAI.AIState.fire)
        {
            owner.stateMachine.ChangeState(fireState.Instance);
        }
    }
}
