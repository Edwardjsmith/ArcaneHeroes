using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onColText : MonoBehaviour
{
    public Text whoopsText;

	void OnCollisionEnter2D(Collision2D whoops)
    {
        if(whoops.gameObject.tag == "Player")
        {
            whoopsText.gameObject.SetActive(true);
        }
    }
}