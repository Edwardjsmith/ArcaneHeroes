using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
 

    public void QuitTheGame()
    {
        Debug.Log("Quit the Game");
        Application.Quit();
    }
}