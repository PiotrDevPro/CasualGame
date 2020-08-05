using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClinGo : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Main.manage.isTapToPlay && !Main.manage.isGo )
        {
            if (PlayerPrefs.GetInt("level") == 11)
            {
                GetComponent<Animator>().SetTrigger("push");
                GameObject sound = GameObject.Find("Push");
                sound.GetComponent<AudioSource>().Play();
            }
        }
    }
}
