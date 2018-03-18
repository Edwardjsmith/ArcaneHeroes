using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class setSelectedButton : MonoBehaviour {

   
    public GameObject selectedButton;
    public EventSystem changeButton;

    private void OnEnable()
    {
        if (selectedButton.activeSelf == true)
        {
            changeButton.SetSelectedGameObject(selectedButton);
        }
    }

}
