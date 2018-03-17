using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour {
    public int FPS;
    // Use this for initialization
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
    }
    void Update()
    {
        if (FPS != Application.targetFrameRate)
        {
            Application.targetFrameRate = FPS;
        }
    }
}
