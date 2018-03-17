using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : projectile
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.Instance.damage();


            Destroy(gameObject);
        }


    }
}
