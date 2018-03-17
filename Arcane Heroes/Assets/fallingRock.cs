using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingRock : MonoBehaviour {

    bool isPlayerThere;
    public GameObject lineOfSight;
    public GameObject boulder;
   
    float timer;
	// Use this for initialization
	void Start ()
    {
        isPlayerThere = false;
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        isPlayerThere = Physics2D.Linecast(transform.position, lineOfSight.transform.position, 1 << LayerMask.NameToLayer("Player"));
        
        if(isPlayerThere && timer <= 0)
        {
            Instantiate(boulder, transform, false);

            timer = 3.0f;
        }
        timer -= Time.deltaTime;
	}


}
