using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPos : MonoBehaviour {

    GameObject player;
    Vector3 offset;
    // Use this for initialization
    void Start ()
    {
       player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
	}
}