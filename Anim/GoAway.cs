using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAway : MonoBehaviour
{
    public static GoAway manage;
    
     void Awake()
    {
        manage = this;
    }

    void OnMouseDown()
    {
        if (Main.manage.isTapToPlay && !Main.manage.isGo)
        {
            if (PlayerPrefs.GetInt("level") == 0)
            {
                GetComponent<Animator>().SetTrigger("Push");
                GetComponent<AudioSource>().Play();
                GameObject trainingcursor = GameObject.Find("MouseIcon");
                trainingcursor.SetActive(false);
                //Destroy(gameObject, 2f);
            }
            if (PlayerPrefs.GetInt("level") == 3)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetTrigger("Push");
            }
        }
        
    }
}
