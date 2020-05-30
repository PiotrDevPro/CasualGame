﻿using System;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Purchasing;


// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAPManager : Singleton<IAPManager>//, IStoreListener
{
    // private static IStoreController m_StoreController;          // The Unity Purchasing system.
    // private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public string NOADS = "remove_ads_ttb";
    public string COIN100 = "coin_100_ttb";
    public string COIN500 = "coin_500_ttb";
    public string COIN1000 = "coin_1000_ttb";
    public string COIN2000 = "coin_2000_ttb";
    public string COIN10000 = "coin_10000_ttb";

    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        //  if (m_StoreController == null)
        //   {
        // Begin to configure our connection to Purchasing
        //     InitializePurchasing();
        // }
    }
}

     /*   public void InitializePurchasing()
        {
            // If we have already connected to Purchasing ...
          //  if (IsInitialized())
          //  {
                // ... we are done here.
          //      return;
           // }

            // Create a builder, first passing in a suite of Unity provided stores.
            //var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            //builder.AddProduct(COIN100, ProductType.Consumable);
            //builder.AddProduct(COIN500, ProductType.Consumable);
            //builder.AddProduct(COIN1000, ProductType.Consumable);
            //builder.AddProduct(COIN2000, ProductType.Consumable);
            //builder.AddProduct(COIN10000, ProductType.Consumable);
            //builder.AddProduct(NOADS, ProductType.NonConsumable);

          //  UnityPurchasing.Initialize(this, builder);
        }


      //  private bool IsInitialized()
      //  {
            // Only say we are initialized if both the Purchasing references are set.
        //    return m_StoreController != null && m_StoreExtensionProvider != null;
       // }


        public void Buy100()
        {
            BuyProductID(COIN100);
        }

        public void Buy500()
        {
            BuyProductID(COIN500);
        }

        public void Buy1000()
        {
            BuyProductID(COIN1000);
        }

        public void Buy2000()
        {
            BuyProductID(COIN2000);
        }

        public void Buy10000()
        {
            BuyProductID(COIN10000);
        }

        public void BuyAds()
        {
            BuyProductID(NOADS);
        }

        void BuyProductID(string productId)
        {
            // If Purchasing has been initialized ...
            if (IsInitialized())
            {
                // ... look up the Product reference with the general product identifier and the Purchasing 
                // system's products collection.
                Product product = m_StoreController.products.WithID(productId);

                // If the look up found a product for this device's store and that product is ready to be sold ... 
                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                    // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                    // asynchronously.
                    m_StoreController.InitiatePurchase(product);
                }
                // Otherwise ...
                else
                {
                    // ... report the product look-up failure situation  
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            // Otherwise ...
            else
            {
                // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
                // retrying initiailization.
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }


        // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
        // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
        public void RestorePurchases()
        {
            // If Purchasing has not yet been set up ...
            if (!IsInitialized())
            {
                // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            // If we are running on an Apple device ... 
            if (Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.OSXPlayer)
            {
                // ... begin restoring purchases
                Debug.Log("RestorePurchases started ...");

                // Fetch the Apple store-specific subsystem.
                var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
                // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
                // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
                apple.RestoreTransactions((result) =>
                {
                    // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                    // no purchases are available to be restored.
                    Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                });
            }
            // Otherwise ...
            else
            {
                // We are not running on an Apple device. No work is necessary to restore purchases.
                Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            }
        }


        //  
        // --- IStoreListener
        //

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            Debug.Log("OnInitialized: PASS");

            // Overall Purchasing system, configured with products for this application.
            m_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            m_StoreExtensionProvider = extensions;
        }


        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            // A consumable product has been purchased by this user.
            if (String.Equals(args.purchasedProduct.definition.id, COIN100, StringComparison.Ordinal))
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                Main.manage._coinFx.SetActive(true);
                Invoke("TimeToDeactivate", 0.5f);
            }

            if (String.Equals(args.purchasedProduct.definition.id, COIN500, StringComparison.Ordinal))
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 500);
                Main.manage._coinFx.SetActive(true);
                Invoke("TimeToDeactivate", 0.5f);
            }

            if (String.Equals(args.purchasedProduct.definition.id, COIN1000, StringComparison.Ordinal))
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1000);
                Main.manage._coinFx.SetActive(true);
                Invoke("TimeToDeactivate", 0.5f);
            }

            if (String.Equals(args.purchasedProduct.definition.id, COIN2000, StringComparison.Ordinal))
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 2000);
                Main.manage._coinFx.SetActive(true);
                Invoke("TimeToDeactivate", 0.5f);
            }

            if (String.Equals(args.purchasedProduct.definition.id, COIN10000, StringComparison.Ordinal))
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10000);
                Main.manage._coinFx.SetActive(true);
                Invoke("TimeToDeactivate", 0.5f);
            }
            else if (String.Equals(args.purchasedProduct.definition.id, NOADS, StringComparison.Ordinal))
            {
                PlayerPrefs.SetInt("NoAds", 1);
                Main.manage.NoAdsButtonActive();
                print("RemoveAdsSuccesfull");
            }
            // Or ... an unknown product has been purchased by this user. Fill in additional products here....
            else
            {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }

            return PurchaseProcessingResult.Complete;
        }

        public string GetProducerPriceFromStore(string id)
        {
            if (m_StoreController != null && m_StoreController.products != null)
            
              return  m_StoreController.products.WithID(id).metadata.localizedPriceString;
                    else
                    return "";
            
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {

            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }


        private void TimeToDeactivate()
        {
            Main.manage._coinFx.SetActive(false);
        }
    }
    */