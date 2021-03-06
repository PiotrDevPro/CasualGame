﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerPrefs.GetInt("level")==2 && collision.collider.tag == "Player")
        {
            PlayerController.manage.Vibro();
        }
        if (collision.collider.tag == "Grnd")
        {
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();
            GameObject crtLayer = GameObject.Find("crate");
            PlayerController.manage.Vibro();


            if (PlayerPrefs.GetInt("level") == 13){
                crtLayer.GetComponent<BoxCollider>().tag = "Untagged";
            }

            if (PlayerPrefs.GetInt("level") == 28)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            }

            if (PlayerPrefs.GetInt("level") == 13)
            {
                GetComponent<BoxCollider>().isTrigger = false;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }


        }
        if (collision.collider.tag == "ISound")
        {
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();
            PlayerController.manage.Vibro();
        }

            if (collision.collider.tag == "Player")
        {
            PlayerController.manage.Vibro();
        }

            if (collision.collider.tag == "Non")
        {
            
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();
            PlayerController.manage.Vibro();

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
            PlayerController.manage.Vibro();

        }

        if (col.name == "loseTrig")
        {
            GoAway.manage.isFailed = true;
            
        }

        if (col.name == "DeadTrig")
        {
            GameObject dedTrig = GameObject.Find("DeadTrig");
            dedTrig.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "DeadTrig")
        {
            GameObject dedTrig = GameObject.Find("DeadTrig");
            dedTrig.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "DeadTrig")
        {
            GameObject dedTrig1 = GameObject.Find("DeadTrig");
            dedTrig1.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void Update()
    {
       // print(GetComponent<Transform>().position);
    }
}
