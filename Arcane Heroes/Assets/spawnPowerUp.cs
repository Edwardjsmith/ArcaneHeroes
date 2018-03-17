using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPowerUp : MonoBehaviour {

    public GameObject health;
    public GameObject splitFire;

    int choice;
    // Update is called once per frame

    private void Update()
    {
        choice = Random.Range(0, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            playerController.Instance.damage();
        }

        Destroy(gameObject);

        

        if (choice == 1)
        {
            Instantiate(health, gameObject.transform);
        }
        else if(choice == 2)
        {
            Instantiate(splitFire, gameObject.transform);
        }
    }
}
