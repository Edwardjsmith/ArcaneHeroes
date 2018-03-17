using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleMeDown : MonoBehaviour
{
    bool spawn = true;
    void Update()
    {
        if (transform.localScale == new Vector3(0.15f, 0.15f, 0.0f))
        {
            spawn = false;
            StartCoroutine("Wait");

        }
        if (transform.localScale != new Vector3(0.15f,0.15f,0.0f) && spawn == true)
        {
            transform.localScale += new Vector3(0.005f, 0.005f, 0);

        }
        if (transform.localScale == new Vector3(0.0f, 0.0f, 0.0f))
        {
            transform.localScale = new Vector3(0.0f, 0.0f, 0);
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        if (transform.localScale != new Vector3(0.0f, 0.0f, 0.0f))
        {
            transform.localScale -= new Vector3(0.005f, 0.005f, 0);
        }
    }
}
