using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private GameObject anim;

    private void Start()
    {
        anim = GameObject.Find("HelloWord");
    }
    public void PlayA()
    {
        anim.GetComponent<Animator>().SetTrigger("play");
    }
    private void Update()
    {
       
    }
}
