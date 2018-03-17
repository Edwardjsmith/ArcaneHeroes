using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbingScript : MonoBehaviour {

    private Vector2 pos1;
    private Vector2 pos2;

  
 

    float speed = 1.0f;
    // Use this for initialization
    void Start ()
    {
        pos1 = new Vector2(transform.position.x, transform.position.y + 0.1f);
        pos2 = new Vector2(transform.position.x, transform.position.y - 0.1f);
        
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
