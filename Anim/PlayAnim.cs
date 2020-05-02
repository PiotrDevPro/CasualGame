using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private int a = 0;
    private void OnMouseDown()
    {


        if (Main.manage.isTapToPlay && !Main.manage.isGo )
        {
            if (PlayerPrefs.GetInt("level") == 11)
            {
                a += 1;
                GetComponent<Animator>().SetBool("push",true);
                GameObject sound = GameObject.Find("Push");
                sound.GetComponent<AudioSource>().Play();
                
                if (a==1)
                {
                    GetComponent<Animator>().SetTrigger("pushBack");
                    a =0;
                }
            }
        }
    }
        
}
