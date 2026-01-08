using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public int PowerShop;
    public int PriceShop;
    public bool IsActive;

    public GoldButtonScript GoldAmount;
    public TextMeshProUGUI Prix;
    public GameObject ShopScreen;
    public PauseSystem PauseSystem;

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
            Prix.text = PriceShop.ToString("00");
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

                print(GoldAmount.Wallet);
                print(PriceShop);
                if (GoldAmount.Wallet >= PriceShop)
                {
                    GoldAmount.Wallet -= PriceShop;
                    PriceShop = Mathf.CeilToInt(PriceShop * 1.20f);
                    GoldAmount.Power += PowerShop;
                    print("Achat Effectue");
                    GoldAmount.goldText.text = GoldAmount.Wallet.ToString("00");
                    GoldAmount.WalletShop.text = GoldAmount.Wallet.ToString("Wallet : 00");

                }

            }
        }
    }
}
