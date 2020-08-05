using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RateManager : Singleton<RateManager>
{
    public static RateManager manage;
    [SerializeField]
    private RateBox rateBox;
    [SerializeField]
    public bool rateoff = false;
    private void Start()
    {
        rateBox.gameObject.SetActive(false);
    }
}
