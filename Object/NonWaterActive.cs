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
                GameObject smokeEffct = GameObject.Find("SmokeWhite");
                smokeEffct.GetComponent<ParticleSystem>().Play();
               // GameObject WaterFireSnd = GameObject.Find("WaterFire");
               // WaterFireSnd.GetComponent<AudioSource>().Play();

        }
        if (col.collider.tag == "NonWater")
        { 
            Destroy(gameObject);
        }
        //  if (col.collider.tag == "Non")
        //  {

        //   GameObject NormalGround1 = GameObject.Find("NormalGround");
        //   NormalGround1.GetComponent<BoxCollider>().tag = "Non";
        //    Destroy(gameObject);

    }
}


