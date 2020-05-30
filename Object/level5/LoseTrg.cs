using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Spikes")
        {
            //GoAway.manage.isFailed = true;
            GameObject blocktrig = GameObject.Find("left1");
            blocktrig.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spikes")
        {
            GameObject blocktrig = GameObject.Find("left1");
            blocktrig.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
