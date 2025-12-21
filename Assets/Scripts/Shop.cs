using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public GoldButtonScript GoldAmount;
    public int Power;
    public int Price;
    public TextMeshProUGUI Prix;
    public GameObject ShopScreen;
    public PauseSystem PauseSystem;
    public bool actif;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(ShopScreen != null) 
        { 
            ShopScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Prix != null)
        {
            Prix.text = Price.ToString("00");
        }
    }

    public void OpenShop()
    {
        ShopScreen.SetActive(true);
        PauseSystem.Pause = true;
    }
    public void CloseShop()
    {
        ShopScreen.SetActive(false);
        PauseSystem.Pause = false;
    }
    public void BuyThings()
    {
        if (ShopScreen != null)
        {
            if (PauseSystem != null)
            {
                    
                if (GoldAmount.Wallet >= Price)
                    {
                        GoldAmount.Wallet -= Price;
                        Price = Mathf.CeilToInt(Price * 1.20f);
                        GoldAmount.Power += Power;
                        print("Achat Effectue");
                        GoldAmount.goldText.text = GoldAmount.Wallet.ToString("00");
                        GoldAmount.WalletShop.text = GoldAmount.Wallet.ToString("Wallet : 00");

                    }

            }
        }
    }
}
