using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatOntheWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.tag == "water")
        {
            GameObject blamm = GameObject.Find("Blam");
            blamm.GetComponent<HTSpriteSequencer>().enabled = true;
            GameObject waterBlow = GameObject.Find("WaterBoiling");
            waterBlow.GetComponent<ParticleSystem>().Play();
            GameObject wtrSound = GameObject.Find("wtrSnd");
            wtrSound.GetComponent<AudioSource>().Play();
        }
    }
}
