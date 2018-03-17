using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCanvas : MonoBehaviour {

    public Canvas canvas;
	// Use this for initialization
	void Start ()
    {
        Instantiate(canvas);
    }
	
	
}
