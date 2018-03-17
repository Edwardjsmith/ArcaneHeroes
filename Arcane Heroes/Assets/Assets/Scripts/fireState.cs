using state;

using UnityEngine;

public class fireState : State<baseAI>
{
    private static fireState instance;

    
    private fireState()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public static fireState Instance
    {
        get
        {
            if (instance == null)
            {
                new fireState();
            }
            return instance;
        }
    }



    public override void EnterState(baseAI owner)
    {
        Debug.Log("Entering fire");
    }


    public override void ExitState(baseAI owner)
    {
        Debug.Log("Exiting fire");
    }

    public override void UpdateState(baseAI owner)
    {

        
        if (owner.currentState == (int)baseAI.AIState.chase)
        {
            owner.stateMachine.ChangeState(chaseState.Instance);
        }
        if (owner.currentState == (int)baseAI.AIState.idle)
        {
            owner.stateMachine.ChangeState(idleState.Instance);
        }
    }
}
