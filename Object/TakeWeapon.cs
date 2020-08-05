using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapon : MonoBehaviour
{
    public static TakeWeapon manage;
    private GameObject plr;
    private int count = 0;
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            Destroy(gameObject,0.01f);
            GameObject wp1 = GameObject.Find("SwordP1P");
            wp1.GetComponent<SpriteRenderer>().enabled = true;
            wp1.GetComponent<BoxCollider>().enabled = true;
        }
        if (col.collider.tag == "Grnd")
        {
            GameObject snd = GameObject.Find("SwordDrop");
            snd.GetComponent<AudioSource>().Play();
        }
    }

    private void Update()
    {
    }
}
