using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hasKey : MonoBehaviour {

    public Sprite key;
    
    
	// Use this for initialization
	void Start ()
    {
        GetComponent<Image>().sprite = key;
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame

}
