using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : projectile {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyAir" && gameObject.tag == "fireProjectile")
        {
            collision.gameObject.GetComponent<baseAI>().damage();
        }
        else if (collision.gameObject.tag == "enemyFire" && gameObject.tag == "waterProjectile")
        {
            collision.gameObject.GetComponent<baseAI>().damage();
        }
        else if (collision.gameObject.tag == "enemyWater" && gameObject.tag == "airProjectile")
        {
            collision.gameObject.GetComponent<baseAI>().damage();
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<baseAI>().damage();
        }
        
        else
        {
            Debug.Log("No effect..");
        }

        Destroy(gameObject);
    }

}
