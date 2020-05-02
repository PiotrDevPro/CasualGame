using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GoAway : MonoBehaviour
{
    public static GoAway manage;
    private GameObject clinn;
    private GameObject clinn1;
    private GameObject clinn2;
    private GameObject clin_level10;
    private GameObject clin_level12;
    private int n = 0;
    public bool isFailed = false;
    
     void Awake()
    {
        manage = this;
    }
    private void Start()
    {
        clinn = GameObject.Find("clinH");
        clinn1 = GameObject.Find("ClinH1");
        clinn2 = GameObject.Find("clin (7)");
        clin_level10 = GameObject.Find("clinVertical");
        //clin_level10 = GameObject.Find("clinVertical");
    }


    void OnMouseDown()
    {

        if (Main.manage.isTapToPlay && !Main.manage.isGo)
        {
            // n = 0;
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
            if (PlayerPrefs.GetInt("level") == 4)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetTrigger("push");
            }

            if (PlayerPrefs.GetInt("level") == 5)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetTrigger("push");

            }

            if (PlayerPrefs.GetInt("level") == 6)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetTrigger("push");

            }
            if (PlayerPrefs.GetInt("level") == 7)
            {

                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("push", true);
                n += 1;
                if (n == 1)
                {
                    GetComponent<Animator>().SetTrigger("pushBack");
                    n = 0;
                }

            }
            if (PlayerPrefs.GetInt("level") == 8)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("push", true);

            }
            if (PlayerPrefs.GetInt("level") == 9)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("push", true);

            }
            if (PlayerPrefs.GetInt("level") == 10)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("push", true);

            }
            if (PlayerPrefs.GetInt("level") == 11)
            {
                GetComponent<Animator>().SetBool("push", true);
                GetComponent<AudioSource>().Play();
                GameObject clinnn = GameObject.Find("clin");
                GameObject clinnn2 = GameObject.Find("clin (5)");

                if (clinnn.GetComponent<Transform>().position.x > 1)
                {
                    GetComponent<AudioSource>().Play();
                    GetComponent<Animator>().SetBool("push", true);
                    
                }

                if (clinnn.GetComponent<Transform>().position.x < -0)
                {
                    GetComponent<Animator>().SetTrigger("pushBack");
                    GetComponent<Animator>().SetBool("push", false);
                }
                
                //  if (clinnn2.GetComponent<Transform>().position.x > 1)
                //  {
                //      GetComponent<AudioSource>().Play();
                //      GetComponent<Animator>().SetBool("push", true);
                //  }
                //  if (clinnn2.GetComponent<Transform>().position.x < -0)
                //  {
                //     GetComponent<Animator>().SetTrigger("pushBack");
                //      GetComponent<Animator>().SetBool("push", false);
                // }
            }

            if (PlayerPrefs.GetInt("level") == 12)
            {
                GetComponent<Animator>().SetTrigger("push");
                GetComponent<AudioSource>().Play();
            }
            if (PlayerPrefs.GetInt("level") == 13)
            {
                GetComponent<Animator>().SetTrigger("push");
                GetComponent<AudioSource>().Play();
            }

            if (PlayerPrefs.GetInt("level") == 14)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("push", true);

            }

            if (PlayerPrefs.GetInt("level") == 15)
            {
                GameObject sound = GameObject.Find("Push");
                sound.GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("push", true);

            }
        }
    }

    void Lose()
    {
        if (PlayerPrefs.GetInt("level") == 12) {
            {
                if (clinn2.transform.position.x >= 5f)
                    isFailed = true;

            }
        }

        if (PlayerPrefs.GetInt("level") == 9)
        {
            if (clin_level10.GetComponent<Transform>().position.x <= -3f)
            {
                isFailed = true;
            }
        }

        if (PlayerPrefs.GetInt("level") == 11)
        {
            if (clin_level10.GetComponent<Transform>().position.x <= -3f)
            {
                isFailed = true;
            }
        }

        if(PlayerPrefs.GetInt("level") == 8)
        {
            if (clinn.transform.position.x >= 6f && clinn1.transform.position.x < 0 | Rope2DMouseCutter.count == 0) //&& clinn2.transform.position.y >= -2.89f)
            {
                isFailed = true;
            }
        }
    }
    private void Update()
    {
        print(clinn1.transform.position.x);

        //print(clin_level10.GetComponent<Transform>().position.x);
        if (PlayerPrefs.GetInt("level") == 8 || PlayerPrefs.GetInt("level") == 12 || PlayerPrefs.GetInt("level") == 9)
        {
            Lose();
        }
        

    }
}
