using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YokaiScript : MonoBehaviour
{
    public int YK;
    public GoldButtonScript GoldAmount;
    public float Temps;
    public int Price;
    public int Value;
    public Image icon;
    public bool Pause;
    public GameObject go;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MyCoroutine());
        YK = 0;
        Pause = false;

        icon = GetComponent<Image>();
    }

    void Update()
    {
        if (GoldAmount.Wallet >= Price)
        {
            icon.color = Color.white;
        }
        else
        {
            icon.color = Color.black;
        }
    }

     public void MettrePause()
    {
        Pause = !Pause;
        go.SetActive(Pause);
    
    }
    public IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (Pause == false)
            {
                Yokai();
            }
            yield return new WaitForSeconds(Temps); 
        }
    }
    public void Yokai()
    {
        GoldAmount.Wallet += Value*YK;
    }

    public void BuyYokai()
    {
        if (GoldAmount.Wallet >= Price)
        {
            GoldAmount.RemoveGold(Price);

            YK += 1;
            Price = Mathf.CeilToInt(Price * 1.20f);
        }
    }



}
