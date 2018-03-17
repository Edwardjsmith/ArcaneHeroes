using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakWall : MonoBehaviour {

    Rigidbody2D rigid;
    // Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.isKinematic = true;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "airProjectile" || collision.gameObject.tag == "fireProjectile" || collision.gameObject.tag == "waterProjectile")
        {
            rigid.isKinematic = false;
            rigid.AddForce(new Vector2 (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x / 2, 0));
            Destroy(gameObject, 2.0f);

            Debug.Log("Wall hit");
        }
    }
}
