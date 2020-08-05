using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivApp : MonoBehaviour
{
    
    void Start()
    {
        
        //Invoke("Latency",0.1f);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
           // Amplitude.Instance.logEvent("AppClose");
           // FbManager.manage.CloseApp();

        }
    }

    void Latency()
    {
       // FbManager.manage.OpenApp();
    }
}
