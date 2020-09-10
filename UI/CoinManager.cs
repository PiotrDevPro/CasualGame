using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager manage;
    private bool startMove;
    private GameObject movingTo;
    private readonly float speed = 250f;

    void Awake()
    {
        manage = this;    
    }
    private void Start()
    {
        movingTo = GameObject.Find("Goldx");
        // collide = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (startMove)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movingTo.transform.position, step);
        }

        if (gameObject.transform.position == movingTo.transform.position)
            gameObject.SetActive(false);
    }

    public void StartFx()
    {
      startMove = true;
      GameObject coinImg = GameObject.Find("animatedCoin");
      coinImg.GetComponent<SpriteRenderer>().enabled = true;
    }
}


