using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerWaterAI : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            waterAI.fireState = true;
            Debug.Log("Fire!");
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            waterAI.fireState = false;
            Debug.Log("Cease Fire!");
        }
    }
}
