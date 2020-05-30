using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatTrigg : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "boatTrig")
        {
            
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject boat2d = GameObject.Find("boatt");
            boat2d.GetComponent<SpriteRenderer>().enabled = true;
            boat2d.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GameObject gndActive = GameObject.Find("groundActive");
            gndActive.GetComponent<BoxCollider>().enabled = true;

        }
    }
}
