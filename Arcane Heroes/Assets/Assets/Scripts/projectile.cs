using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public AudioSource spellSound;
    public float lifeTime;
    
   
	// Use this for initialization
	void Start ()
    {
            Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}

