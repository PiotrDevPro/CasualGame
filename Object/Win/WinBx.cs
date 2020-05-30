using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBx : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Grnd")
        {
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();
            if (PlayerPrefs.GetInt("level") == 19)
            {
                GetComponent<BoxCollider>().isTrigger = false;
                GetComponent<Rigidbody>().isKinematic = false;
            }
            //crtLayer.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        if (collision.collider.tag == "Player")
        {
            
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
           // GameObject playa = GameObject.Find("Default");
           // playa.GetComponent<Transform>().position = transform.position - transform.up; 
            //crtLayer.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        if (collision.collider.tag == "Enemy")
        {

           
            
        }
    }

    
}
