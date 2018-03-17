using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
 
    public static void staticChange(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void change(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
