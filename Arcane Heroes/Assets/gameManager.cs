using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {


    public static int scene;

    


    private static gameManager _instance;

    public static gameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new gameManager();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this);
        
	}

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        
        
    }
   
}
