using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Notif : MonoBehaviour
{
    private int counter = 0;
    void Start()
    {
       // GleyNotifications.Initialize();

    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            counter += 1;
            
             //   GleyNotifications.SendNotification("Tap Tap Man, WOW! More Bonus!", "Come on, We waiting for you!", new System.TimeSpan(24, 0, 0), "icon_0", "icon_1", "");
          //  if (counter == 1)
          //  {
          //      Amplitude.Instance.logEvent("Push notification was sent");
         //   }
            
        } else
        {
         //   GleyNotifications.Initialize();
        }
    }
}
