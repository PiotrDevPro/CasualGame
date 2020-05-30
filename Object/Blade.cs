using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;

    Rigidbody2D rb;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
     //   if (Main.manage.isTapToPlay && !PlayerController.manage.isStart && !Main.manage.IsSettingActive)
    //    {
            if (Input.GetMouseButtonDown(0))
            {
                StartCutting();

            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopCutting();

            }

            if (isCutting)
            {
                UpdateCut();
            }
      //  }
         
    }

    void UpdateCut()
    {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void StartCutting()
    {
        isCutting = true;
        Invoke("latency",0.1f);
    }

    void StopCutting()
    {
        isCutting = false;
        GetComponentInChildren<TrailRenderer>().enabled = false;
    }

    void latency()
    {
        GetComponentInChildren<TrailRenderer>().enabled = true;
    }
}
