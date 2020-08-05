using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPHorizont : MonoBehaviour
{


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
        if (col.name == "leftH")
        {
            isMove = false;
            isMoveBack = true;
            isStart = false;
            //print("End");

        }

        if (col.name == "rightH" && isStart)
        {
            isMoveBack = false;
            isMove = true;
            isStart = false;
            //print("back");

        }
    }

    private void OnTriggerStay(Collider col)
    {


        if (col.name == "leftH")
        {
            isMove = false;
            isMoveBack = true;
            isStart = false;
            //print("End");

        }

        if (col.name == "rightH" && isStart)
        {
            isMoveBack = false;
            isMove = true;
            //print("back");

        }
    }

    void Move()
    {
        Vector3 temp = Vector3.left;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, 1f * Time.deltaTime);
    }

    void MoveBack()
    {
        Vector3 temp = -Vector3.left;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, 1f * Time.deltaTime);
    }

    private void Update()
    {
        if (Main.manage.isTapToPlay)
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
