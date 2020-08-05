using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordd : MonoBehaviour
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
            
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }
}
