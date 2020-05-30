using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasUpDown : MonoBehaviour
{
    bool WallDetect = false;
    bool WallDetectRight = false;
    bool clinDetectRight = false;
    bool clinDetectLeft = false;
    bool EnemyDetect = false;

    void Move()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 12.25f);// ForceMode.Force);
    }

    
    void MoveRightLeft()
    {
        if (PlayerPrefs.GetInt("level") == 14)
        {
            if (WallDetect && clinDetectRight)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.left * 4.25f);
            }

            if (WallDetect && clinDetectLeft)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.right * 4.25f);
            }
        }

        if (PlayerPrefs.GetInt("level") == 26)
        {


            if (WallDetect)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.left * 7.25f);
            }

            if (WallDetect && clinDetectLeft)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.right * 7.25f);
            }
        }
    }
    void DetectColiderTop()
    {
        Debug.DrawRay(transform.position + transform.up / 12f, transform.up * 0.02f, Color.cyan);
        RaycastHit info;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position + transform.up / 12f, transform.up * 0.02f, out info, 0.02f, mask))
        {
            WallDetect = true;
            MoveRightLeft();
          //  print("walldetect");
        }
        else
        {
            Move();
            WallDetect = false;
           // print("wallNoDetect");

        }

    }

    void DetectColiderRight()
    {
        Debug.DrawRay(transform.position + transform.right / 12f, transform.right * 0.02f, Color.cyan);
        RaycastHit info;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position + transform.right / 12f, transform.right * 0.02f, out info, 0.02f, mask))
        {
            WallDetectRight = true;
            
            Move();
            
        }
        else
        {
            
            WallDetectRight = false;
            
        }

    }
    void DetectRightClin()
    {
        Debug.DrawRay(transform.position + transform.up / 1000f, transform.right * 0.7f, Color.yellow);
        RaycastHit info;
        int mask = 1 << 8;
        if (Physics.Raycast(transform.position + transform.up / 1000f, transform.right * 0.7f, out info, 0.7f, mask))
        {
            clinDetectRight = true;
            
            MoveRightLeft();
        }
        else
        {

            clinDetectRight = false;
            
        }
    }
    void DetectLeftClin()
    {
        Debug.DrawRay(transform.position + transform.up / 1000f, -transform.right * 0.7f, Color.yellow);
        RaycastHit info;
        int mask = 1 << 8;
        if (Physics.Raycast(transform.position + transform.up / 1000f, -transform.right * 0.7f, out info, 0.7f, mask))
        {
            clinDetectLeft = true;
            
            MoveRightLeft();
        }
        else
        {

            clinDetectLeft = false;
            
        }
    }

    void DetectEnemy()
    {

    }
    void FixedUpdate()
    {
        DetectColiderTop();
        DetectRightClin();
        DetectLeftClin();
        DetectColiderRight();
    }
}
