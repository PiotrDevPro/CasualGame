using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasUpDown : MonoBehaviour
{
    bool WallDetect = false;
    bool WallDetectRight = false;
    bool WallDetectLeft = false;
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
                GetComponent<Rigidbody>().AddForce(Vector3.left * 8.25f);
            }

            if (WallDetect && clinDetectLeft)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.right * 8.25f);
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
        Debug.DrawRay(transform.position + transform.up / 100f, transform.up * 0.05f, Color.cyan);
        RaycastHit info;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position + transform.up / 100f, transform.up * 0.05f, out info, 0.05f, mask))
        {
            WallDetect = true;
            MoveRightLeft();
           // print("walldetect");
        }
        else
        {
            Move();
            WallDetect = false;
            //print("wallNoDetect");

        }

    }

    void DetectColiderTopRight()
    {
        Debug.DrawRay(transform.position + transform.right / 100f, transform.up * 0.03f, Color.cyan);
        RaycastHit info;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position + transform.right / 100f, transform.up * 0.03f, out info, 0.03f, mask))
        {
            WallDetectRight = true;
            MoveRightLeft();
           // print("walldetect");
        }
        else
        {
            Move();
            WallDetectRight = false;
          //  print("wallNoDetect");

        }

    }

    void DetectColiderTopLeft()
    {
        Debug.DrawRay(transform.position - transform.right / 12f, transform.up * 0.1f, Color.cyan);
        RaycastHit info;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position - transform.right / 12f, transform.up * 0.1f, out info, 0.1f, mask))
        {
            WallDetectLeft = true;
            MoveRightLeft();
          //  print("walldetect");
        }
        else
        {
            Move();
            WallDetectLeft = false;
           // print("wallNoDetect");

        }

    }

    void DetectColiderRight()
    {
        Debug.DrawRay(transform.position + transform.right / 100f, transform.right * 0.02f, Color.cyan);
        RaycastHit info;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position + transform.right / 100f, transform.right * 0.02f, out info, 0.02f, mask))
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
        Debug.DrawRay(transform.position + transform.up / 1000f, transform.right * 1.7f, Color.yellow);
        RaycastHit info;
        int mask = 1 << 8;
        if (Physics.Raycast(transform.position + transform.up / 1000f, transform.right * 1.7f, out info, 1.7f, mask))
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
        Debug.DrawRay(transform.position + transform.up / 1000f, -transform.right * 1.7f, Color.yellow);
        RaycastHit info;
        int mask = 1 << 8;
        if (Physics.Raycast(transform.position + transform.up / 1000f, -transform.right * 1.7f, out info, 1.7f, mask))
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
        //DetectColiderTopRight();
      //  DetectColiderTopLeft();
        DetectRightClin();
        DetectLeftClin();
        DetectColiderRight();
    }
}
