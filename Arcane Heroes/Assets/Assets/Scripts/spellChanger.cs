using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spellChanger : MonoBehaviour {

    public Sprite water;
    public Sprite fire;
    public Sprite wind;
    
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
    {
        if (playerController.spellSelect == 0)
        {
            GetComponent<Image>().sprite = water;
        }
        if (playerController.spellSelect == 1)
        {
            GetComponent<Image>().sprite = wind;
        }
        if (playerController.spellSelect == 2)
        {
            GetComponent<Image>().sprite = fire;
        }
    }
}
