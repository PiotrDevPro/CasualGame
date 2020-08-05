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
            PlayerController.manage.Vibro();
        }

        if (collision.collider.tag == "Player")
        {
            
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if (collision.collider.tag == "Enemy")
        {

           
            
        }
    }

    
}
