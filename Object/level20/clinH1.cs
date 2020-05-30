using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clinH1 : MonoBehaviour
{
    private GameObject clinTop;
    bool isWrong = false;

    private void Start()
    {
        ;
        
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("level") == 19)
        {
            
            TrigProcces();
        }
    }

    void TrigProcces()
    {
        clinTop = GameObject.Find("clin (4)");
        if (clinTop.transform.position.x > 1)
        {
            isWrong = true;
            GameObject deadtrgGrnd = GameObject.Find("DeadTrigGrnd");
            deadtrgGrnd.GetComponent<BoxCollider>().enabled = true;
        }

        if (transform.position.x < 0 && !isWrong)
        {
            GameObject deadtrg = GameObject.Find("DeadTrig");
            deadtrg.GetComponent<BoxCollider>().enabled = true;

        }

        if (clinTop.transform.position.x > 1 && transform.position.x < 0)
        {

            GameObject deadtrgGrnd = GameObject.Find("DeadTrigGrnd");
            deadtrgGrnd.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
