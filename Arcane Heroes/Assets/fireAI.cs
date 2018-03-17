using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAI : baseAI
{

    public static bool fireState;



    public override void Start()
    {
        base.Start();
        entityHealth = 2;
        fireState = false;
        spotted = fireState;
        
    }


    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        

        if (!fireState)
        {
            currentState = (int)AIState.idle;
        }
        else if(fireState)
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

                fire(Spells[0], staff.transform);
                fire(Spells[0], staff.transform, transform.rotation * Quaternion.Euler(0, 0, -45));
                fire(Spells[0], staff.transform, transform.rotation * Quaternion.Euler(0, 0, -90));
                fire(Spells[0], staff.transform, transform.rotation * Quaternion.Euler(0, 0, -135));
                fire(Spells[0], staff.transform, transform.rotation * Quaternion.Euler(0, 0, -180));

                timer = 3.0f;
            }
        }
    }
}

       
    



