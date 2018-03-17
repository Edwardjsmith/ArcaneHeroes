using state;

using UnityEngine;

public class idleState : State<baseAI>
{
    private static idleState instance;

    

    private idleState()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

    public static idleState Instance
    {
        get
        {
            if(instance == null)
            {
                new idleState();
            }
            return instance;
        }
    }

   

    public override void EnterState(baseAI owner)
    {
        Debug.Log("Entering idle");
    }

 
    public override void ExitState(baseAI owner)
    {
        Debug.Log("Exiting idle");
    }

    public override void UpdateState(baseAI owner)
    {
        if(owner.currentState == (int)baseAI.AIState.chase)
        {
            owner.stateMachine.ChangeState(chaseState.Instance);
        }
    }
}
