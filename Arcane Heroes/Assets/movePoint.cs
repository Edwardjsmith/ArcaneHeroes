using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePoint : MonoBehaviour {

    public GameObject movePoint1;
    public GameObject movePoint2;

    bool atMovePoint1;

    private void Start()
    {
        atMovePoint1 = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemyAir")
        {
            if (atMovePoint1 == false)
            {
                transform.position = movePoint1.transform.position;
                atMovePoint1 = true;
            }
            else if(atMovePoint1 == true)
            {
                transform.position = movePoint2.transform.position;
                atMovePoint1 = false;
            }
        }
    }
}
