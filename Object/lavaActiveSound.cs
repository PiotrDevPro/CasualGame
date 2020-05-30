using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaActiveSound : MonoBehaviour
{
    private GameObject lavaEf;

    private void Start()
    {
        lavaEf = GameObject.Find("LavaD");

    }
    private void Update()
    {
        transform.position = lavaEf.GetComponent<Transform>().position;
        
    }
}
