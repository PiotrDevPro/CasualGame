using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPlatform : MonoBehaviour
{
    private int moveCount = 0;
    bool isStart = false;
    bool isMove = false;
    bool isMoveBack = false;
    private void OnMouseDown()
    {
        if (Main.manage.isTapToPlay && !PlayerController.manage.isDead && !Main.manage.IsSettingActive)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            {

                isStart = true;
                GameObject sound = GameObject.Find("Push");
                sound.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "left" || col.name == "left1")
        {
            isMove = false;
            isMoveBack = true;
            isStart = false;
            //print("End");
            
        }

        if (col.name == "right" && isStart)
        {
            isMoveBack = false;
            isMove = true;
            isStart = false;
            //print("back");

        }
    }

    private void OnTriggerStay(Collider col)
    {
        
    
       // if (col.name == "left")
      //  {
      //     isMove = false;
      //      isMoveBack = true;
      //      isStart = false;
      //  }

        if (col.name == "right" && isStart)
        {
            isMoveBack = false;
            isMove = true;
        }
    }

    void Move()
    {
        Vector3 temp = -Vector3.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, 1.4f * Time.deltaTime);
    }

    void MoveBack()
    {
        Vector3 temp = Vector3.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, 1.4f * Time.deltaTime);
    }

    private void Update()
    {
        if (Main.manage.isTapToPlay && !PlayerController.manage.isDead)
        {
            if (isMove && isStart)
            {
                Move();
            }

            if (isMoveBack && isStart)
            {
                MoveBack();
            }
        }
    }
}
