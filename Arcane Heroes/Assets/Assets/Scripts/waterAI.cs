using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterAI : baseAI
{
    
    public static bool fireState;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        timer = 0f;
        grounded = true;
        fireState = false;
        entityHealth = 3;
        projectileSpeed = 300;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (!fireState)
        {
            currentState = (int)AIState.idle;
        }
        else if (fireState)
        {
            currentState = (int)AIState.fire;
           
        }

        manageStates();



    }
    void manageStates()
    {
        if (currentState == (int)AIState.fire)
        {
            if (timer <= 0)
            {
                Spells[0].SetActive(true);



                //fire(Spells[spellSelect], staff);

                waterFire(0);
                

                timer = 4.0f;
            }
        }
    }
   
}