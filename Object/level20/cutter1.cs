using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutter1 : MonoBehaviour
{
    public static cutter1 manage;
    private void Awake()
    {
        manage = this;
    }

    void OnMouseOver()
    {

        if (Main.manage.isTapToPlay && !Main.manage.isCutTheRope && !Main.manage.IsSettingActive)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            {

                Destroy(gameObject);
                

                if (PlayerPrefs.GetInt("level") == 21)
                {
                    GameObject oldCrate = GameObject.Find("Rope2D-ChainBit_7_1");
                    oldCrate.SetActive(false);
                    GameObject oldCrate6 = GameObject.Find("Rope2D-ChainBit_6_1");
                    oldCrate6.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    GameObject oldCrat5 = GameObject.Find("Rope2D-ChainBit_5_1");
                    oldCrat5.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    GameObject oldCrat4 = GameObject.Find("Rope2D-ChainBit_4_1");
                    oldCrat4.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    GameObject Cratee = GameObject.Find("crate_1");
                    Cratee.GetComponent<SpriteRenderer>().enabled = true;
                    Cratee.AddComponent<Rigidbody>().mass = 50;
                    Cratee.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
                    GameObject MetalHit = GameObject.Find("MetalHit2D_1");
                    MetalHit.GetComponent<ParticleSystem>().Play();
                    GoAway.manage.isFailed = true;
                }

                if (PlayerPrefs.GetInt("level") == 29)
                {
                    GameObject oldCrate = GameObject.Find("Rope2D-ChainBit_7_1");
                    oldCrate.SetActive(false);
                    GameObject oldCrate6 = GameObject.Find("Rope2D-ChainBit_6_1");
                    oldCrate6.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    GameObject oldCrat5 = GameObject.Find("Rope2D-ChainBit_5_1");
                    oldCrat5.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    GameObject oldCrat4 = GameObject.Find("Rope2D-ChainBit_4_1");
                    oldCrat4.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    GameObject Cratee = GameObject.Find("crate_1");
                    Cratee.GetComponent<SpriteRenderer>().enabled = true;
                    Cratee.AddComponent<Rigidbody>().mass = 50;
                    Cratee.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
                    GameObject MetalHit = GameObject.Find("MetalHit2D_1");
                    MetalHit.GetComponent<ParticleSystem>().Play();
                }
                if (PlayerPrefs.GetInt("level") == 32)
                {
                    GameObject oldCrate = GameObject.Find("Rope2D-ChainBit_7_1");
                    oldCrate.SetActive(false);
                    GameObject oldCrate6 = GameObject.Find("Rope2D-ChainBit_6_1");
                    oldCrate6.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    GameObject oldCrat5 = GameObject.Find("Rope2D-ChainBit_5_1");
                    oldCrat5.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    GameObject Cratee = GameObject.Find("crate_1");
                    Cratee.GetComponent<SpriteRenderer>().enabled = true;
                    Cratee.AddComponent<Rigidbody>().mass = 50;
                    Cratee.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
                    GameObject MetalHit = GameObject.Find("MetalHit2D_1");
                    MetalHit.GetComponent<ParticleSystem>().Play();
                }

                GameObject sound = GameObject.Find("ropeSound");
                sound.GetComponent<AudioSource>().Play();

            }
        }
    }
}
