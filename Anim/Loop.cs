using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private GameObject clinn;


    void OnMouseDown()
    {
        if (Main.manage.isTapToPlay && !Main.manage.isGo)
        {
            if (PlayerPrefs.GetInt("level") == 7)
            {
                GameObject sound = GameObject.Find("Push");
                sound.GetComponent<AudioSource>().Play();
                clinn = GameObject.Find("clinHorizontal (4)");

                if (clinn.GetComponent<Transform>().position.x > -0.5f)
                {
                    GetComponent<AudioSource>().Play();
                    GetComponent<Animator>().SetBool("push", true);
                }
                if (clinn.GetComponent<Transform>().position.x < -1.9f)
                {
                    GetComponent<Animator>().SetTrigger("pushBack");
                    GetComponent<Animator>().SetBool("push", false);

                }
            }
        
                if (PlayerPrefs.GetInt("level") == 14)
                {

                    GameObject sound = GameObject.Find("Push");
                    sound.GetComponent<AudioSource>().Play();
                    clinn = GameObject.Find("clinVertical (4)");

                    if (clinn.GetComponent<Transform>().position.x > 0.9f)
                    {
                        GetComponent<AudioSource>().Play();
                        GetComponent<Animator>().SetBool("push", true);
                    }
                    if (clinn.GetComponent<Transform>().position.x < 0.05f)
                    {
                        GetComponent<Animator>().SetTrigger("pushBack");
                        GetComponent<Animator>().SetBool("push", false);
                        sound.GetComponent<AudioSource>().Play();
                    }
                }
        }
    }


        void Update()
        {
            clinn = GameObject.Find("clinHorizontal (4)");
          
        }
    
}
