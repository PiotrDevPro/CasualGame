using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinFx : MonoBehaviour
{
    public static CoinFx manage;
    private int count = 0;
    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform target;

    [Space]
    [Header("Available coins : (coins to pool)")]
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();

    [Space]
    [Header("Animation settings")]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField] [Range(0.9f, 2f)] float maxAnimDuration;
    [SerializeField] Ease easyType;

    Vector3 targetPosition;

    void Awake()
    {
        targetPosition = target.position;

        /// prepare pool
        PrepareCoins();
        manage = this;
        
    }

    void PrepareCoins()
    {
        for (int i=0; i<maxCoins; i++)
        {
            GameObject coin;
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }
        
    }
    void Animate(Vector3 collectedCoinPosition, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //check if theres coins in the pool
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);

                //move coin to the collected coin pos
                coin.transform.position = collectedCoinPosition;
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPosition, duration)
                .SetEase(easyType)
                .OnComplete(() =>
                {
                    /// executes whenever coin reach target position
                    coin.SetActive(false);
                    coinsQueue.Enqueue(coin);
                    
                });
            }
        }
    }
    public void AddCoin(Vector3 collectedCoinPosition, int amount)
    {
        Animate(collectedCoinPosition, amount);
    }

    private void Update()
    {
       // if (PlayerController.manage.isTimeToCoinFx)
       // {
         //   count += 1;
         //   if(count == 1)
         //   {
                //AddCoin();
          //  }
       // }
    }

}
