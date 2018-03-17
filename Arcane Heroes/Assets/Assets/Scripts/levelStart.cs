using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelStart : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        transform.position = player.transform.position;
	}
	
	
}
