using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stonee : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Grnd")
        {
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();
            PlayerController.manage.Vibro();

        }

        if(coll.collider.tag == "StoneBlock")
        {
            GetComponent<CapsuleCollider>().tag = "Untagged";
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Grnd")
        {
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();
            PlayerController.manage.Vibro();


        }
    }
}
