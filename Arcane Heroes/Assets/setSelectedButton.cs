using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class setSelectedButton : MonoBehaviour {

    public Button button;



	// Use this for initialization

	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(button.enabled)
        {
            button.Select();
        }
	}
}
