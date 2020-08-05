using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeManager : MonoBehaviour
{
    public static AmplitudeManager manage;
    public int count = 0;
    bool isFirstActivate = false;
    void Awake()
    {
        Amplitude amplitude = Amplitude.Instance;
        amplitude.logging = true;
        amplitude.init("24124fc176fddaf8f13b157c1586cb32");
        manage = this;

        if (PlayerPrefs.GetInt("Install") == 0)
        {
            Amplitude.Instance.logEvent("AppOpen", FirstTime);
            PlayerPrefs.SetInt("Install", PlayerPrefs.GetInt("Install") + 1);
            isFirstActivate = true;
            
        } 

    }
        Dictionary<string, object> FirstTime = new Dictionary<string, object>() {
            {"First time" , true},   
        };
        Dictionary<string, object> SecondTime = new Dictionary<string, object>() {
            {"First time" , false},
        };

    void Start()

    {
        Amplitude.Instance.logEvent("SeenMainScreen");

    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus == true)
        {

            if (count == 0 && !isFirstActivate)
            {
                Amplitude.Instance.logEvent("AppOpen", SecondTime);
                PlayerPrefs.SetInt("box", 0);
                count += 1;
                
                if (PlayerPrefs.GetInt("Subscribe") == 1)
                {
                    Main.manage.SubscribePanel.SetActive(false);
                }
            }
        }
        if (focus == false)
        {
            count = 1;

        }
    }
    private void Update()
    {
        //print(count);
        //print(PlayerPrefs.GetInt("Install"));
    }
}
