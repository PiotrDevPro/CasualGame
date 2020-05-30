using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bxtrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "bxTrig")
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;

        }
    }
}
