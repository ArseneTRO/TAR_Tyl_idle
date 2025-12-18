using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using System.Collections;

public class GoldButtonScript : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI WalletShop;
    public int Wallet;
    public int Power;
    public int Price;
    public Shop Shop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Power = 1;
        Wallet = 0;
    }

    // Update is called once per frame
    void Update()
    {
       goldText.text = Wallet.ToString("00");
       WalletShop.text = Wallet.ToString("Wallet : 00");
    }
    public void Gold()
    {
        Wallet += Power;
    }
    
    public void RemoveGold(int amountToRemove)
    {
        Wallet -= amountToRemove;
    }

    public void echange()
    {
        if (Wallet > 10)
        {
            Wallet -= Price;
            Power += 1;
        }


    }
}
