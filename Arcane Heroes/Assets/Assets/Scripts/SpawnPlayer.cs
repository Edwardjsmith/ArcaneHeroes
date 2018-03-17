using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

    public GameObject playerPrefab;
	// Use this for initialization
	void Start ()
    {
        Instantiate(playerPrefab, GetComponent<Transform>().position, Quaternion.identity);
	}
	
}
