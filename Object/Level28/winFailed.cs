using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winFailed : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        
        if (col.tag == "Finish")
        {
            
            GoAway.manage.isFailed = true;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Finish")
        {

            GoAway.manage.isFailed = true;

        }
    }
}
