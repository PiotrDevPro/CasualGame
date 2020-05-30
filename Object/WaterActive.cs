using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterActive : MonoBehaviour
{
    public static WaterActive manage;
    public int cnt;
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Lava" && PlayerPrefs.GetInt("level")!=19)
        {
            PlayerPrefs.SetInt("count", cnt++);
        }

        if (col.collider.tag == "Lava" && PlayerPrefs.GetInt("level") == 19)
        {
            
        }

            if (col.collider.tag == "Non")
        {
            
            Destroy(gameObject);
        }

        if (col.collider.tag == "Stones")
        {
            if (PlayerPrefs.GetInt("level")== 8 || PlayerPrefs.GetInt("level") == 9)
            {
                Destroy(gameObject);
            }
        }

        if (col.collider.tag == "Grnd")
        {

        }


        if (col.collider.tag == "Enemy")
        {
            
        }
    }

    private void OnTriggerEnter(Collider col)
  {
      if (col.tag == "FailedFromWater")
      {
            if (PlayerPrefs.GetInt("level") != 12 && PlayerPrefs.GetInt("level") != 22)
            {
                GoAway.manage.isFailed = true;
            }

            if (PlayerPrefs.GetInt("level")== 22)
            {
                GoAway.manage.isFailed = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
      }

        if (col.name == "SoftFireAdditiveRed")
        {
            GameObject fire = GameObject.Find("SoftFireAdditiveRed");
            fire.GetComponent<ParticleSystem>().Stop();
            
        }

    }
    private void Awake()
    {
        manage = this;
        PlayerPrefs.SetInt("count", 0);
    }
    private void Update()
  {

  }
}
