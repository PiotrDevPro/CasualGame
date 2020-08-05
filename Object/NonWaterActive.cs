using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonWaterActive : MonoBehaviour
{
    private GameObject clinActive;
    private GameObject clin6Active;
    private int count = 0;

    private void Start()
    {
        clinActive = GameObject.Find("clin (11)");
        clin6Active = GameObject.Find("clin (6)");
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Lava")
        {

            GetComponent<SpriteRenderer>().sortingOrder = 0;
            GameObject smokeEffct = GameObject.Find("SmokeWhite");
            smokeEffct.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }

        if (col.collider.tag == "Non")
        {
            count += 1;
                GameObject smokeEffct = GameObject.Find("SmokeWhite");
                smokeEffct.GetComponent<ParticleSystem>().Play();
            if (count >= 3)
            {
                GameObject DeadActiv = GameObject.Find("loseTrigWater");
                DeadActiv.GetComponent<BoxCollider>().enabled = true;
            }
           // print(count);

        }
        if (col.collider.tag == "NonWater")
        {
            Destroy(gameObject);
        }

        if (col.collider.tag == "Grnd")
        {
            count += 1;
             if (count == 1)
             {
            GameObject wtrSound = GameObject.Find("wtrSnd");
            wtrSound.GetComponent<AudioSource>().volume = 0.1f;
            wtrSound.GetComponent<AudioSource>().Play();
               }
        }

    }
}


