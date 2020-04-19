using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Grnd")
        {
            GameObject drp = GameObject.Find("Drop");
            drp.GetComponent<AudioSource>().Play();
        }
    }
}
