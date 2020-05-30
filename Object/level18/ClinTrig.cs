using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClinTrig : MonoBehaviour
{

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Spikes"))
        {
            print("1");
            GameObject dedTrig = GameObject.Find("DeadTrig");
            dedTrig.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Spikes"))
        {
            print("2");
           // GameObject dedTrig = GameObject.Find("DeadTrig");
           // dedTrig.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "DeadTrig")
        {
            print("3");
        }
    }

}
