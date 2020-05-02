using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Grnd")
        {
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();
            GameObject boxActive = GameObject.Find("box (1)");
            GameObject crtLayer = GameObject.Find("crate");
            if (PlayerPrefs.GetInt("level") == 13){
                crtLayer.GetComponent<BoxCollider>().tag = "Untagged";
            }
            //crtLayer.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        if (collision.collider.tag == "Player")
        {
            if (PlayerPrefs.GetInt("level") == 13)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<BoxCollider>().enabled = false;
                GameObject crtLayer = GameObject.Find("crate");
                crtLayer.GetComponent<SpriteRenderer>().sortingOrder = 0;
                
            }
            //crtLayer.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        if (collision.collider.name == "crate (1)")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        if (collision.collider.name == "BoxTrig")
        {
           
            
        }
        if (collision.collider.name == "BoxTrig")
        {

            GetComponent<Transform>().position = new Vector2(0.6f, -3.4f);
            GetComponent<Transform>().localScale = new Vector2(0.65f, 0.6f);
            GameObject boxtrigActive = GameObject.Find("BoxTrig");
            boxtrigActive.GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            
        }
        if(collision.collider.name == "box (1)")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false; 
            GameObject boxActive = GameObject.Find("box (1)");
            boxActive.GetComponent<SpriteRenderer>().enabled = true;
            boxActive.GetComponent<BoxCollider>().enabled = true;
            boxActive.AddComponent<Rigidbody>().mass = 10;
            boxActive.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            boxActive.GetComponent<BoxCollider>().tag = "Death";
            
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "box (2)")
        {
            GetComponent<Transform>().position = new Vector2(0.7f, 0.5f);
            GetComponent<BoxCollider>().tag = "Untagged";
        }
        if (col.name == "spikes")
        {
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();

        }

        if (col.name == "loseTrig")
        {
            GoAway.manage.isFailed = true;
            print("loses");
        }
    }

    private void Update()
    {
       // print(GetComponent<Transform>().position);
    }
}
