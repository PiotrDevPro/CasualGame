using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    void gasDetected()
    {
        Debug.DrawRay(transform.position + transform.up / 3f , transform.right * 0.5f, Color.yellow);
        RaycastHit info;
        int mask = 1;
        if (Physics.Raycast(transform.position + transform.up / 3f, transform.right * 0.5f, out info, 0.3f, mask))
        {
            print("detected");
        }
        else
        {
            print("Notdetected");

        }
    }

    void MoveGas()
    {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 0.2f, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        MoveGas();
       //gasDetected();
    }
}
