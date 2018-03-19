using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolAI : baseAI {

    public Transform[] patrolPath;
   
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    

    
    
    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        currentPatrolIndex = patrolPath.Length - patrolPath.Length;
        currentPatrolPoint = patrolPath[currentPatrolIndex];
        entityHealth = 1;



    
    }
	
	// Update is called once per frame
	public override void Update ()
    {

        flip();


        base.Update();

        if (!spotted)
        {
            currentState = (int)AIState.idle;
        }
        else if (spotted)
        {
            if (Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) <= 10)
            {
                currentState = (int)AIState.fire;
            }
            else
            {
                currentState = (int)AIState.chase;
            }
        }
        


        manageStates();

      
             
                
         
        stateMachine.Update();
        
        
    }

    void manageStates()
    {
        if (currentState == (int)AIState.idle)
        {
            patrol();
        }
        else if (currentState == (int)AIState.chase)
        {
            chase();
        }
        else
        {
            moveLeft(0);
            moveRight(0);
            Spells[0].SetActive(true);
            if (timer <= 0)
            {
                fire(Spells[0], staff.transform);
                timer = 2.0f;
            }
        }
    }
    

    void chase()
    { 

        

        
        if(gameObject.transform.position.x < player.transform.position.x)
            {
                facingRight = true;
                moveRight(movementSpeed);
            }
        else if (transform.position.x > player.transform.position.x)
   
            {
                facingRight = false;
                moveLeft(movementSpeed);
            }
            
            else
            {
                currentState = (int)AIState.idle;
            }
                stateMachine.Update();
    }

    protected void patrol()
    {

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 1.0f)
        {
            if (currentPatrolIndex + 1 < patrolPath.Length)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPath[currentPatrolIndex];
        }

        Vector2 patrolDirection = currentPatrolPoint.position - transform.position;


        if (patrolDirection.x < 0f)
        {

            moveLeft(movementSpeed);
            facingRight = false;

        }
        else if (patrolDirection.x > 0f)
        {

            moveRight(movementSpeed);
            facingRight = true;

        }

       
    }

   

    
}
