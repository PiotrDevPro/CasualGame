using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMetricPush : MonoBehaviour
{
    void Start()
    {
#if UNITY_IPHONE || UNITY_IOS
    UnityEngine.iOS.NotificationServices.RegisterForNotifications (
      UnityEngine.iOS.NotificationType.Alert |
      UnityEngine.iOS.NotificationType.Badge |
      UnityEngine.iOS.NotificationType.Sound, true);
#endif
    }
}
