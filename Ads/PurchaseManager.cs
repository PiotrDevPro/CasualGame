using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{

    private void Awake()
    {
        
    }
    public void OnPurchaseComplete(Product product)
    {
        print("nice");
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        print("" + product.definition.id + "failed due to" + reason);
    }
}
