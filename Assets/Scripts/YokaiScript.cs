using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YokaiScript : MonoBehaviour
{
    [Header("Variable")]
    public int YK;
    public float Time;
    public int Price;
    public int Value;
    public float Power;

    [Header("References")]
    public Sprite Sprite;
    public YokaiMaker yokaiData;
    public GoldButtonScript GoldAmount;
    public Image icon;
    public PauseSystem pauseSystem;
    public TextMeshProUGUI InfoYokai;
    public TextMeshProUGUI PowerData;
    public YokaiManager yokaiManager;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        icon.sprite = yokaiData.Image;
        Price = yokaiData.Price;
        Value = yokaiData.Value;
        Time = yokaiData.Time;

        StartCoroutine(MyCoroutine());
        YK = 0;
    }

    void Update()
    {
        if (GoldAmount.Wallet >= Price)
        {
            icon.color = Color.white;
            InfoYokai.text = $"{FormatNumber(Price)}G {FormatNumber(Value)}G/{Time}sec";
        }
        else
        {
            icon.color = Color.black;
            InfoYokai.text = $"{FormatNumber(Price)}G ???G/sec";
        }
    }

    public string FormatNumber(int number)
    {
        if (number >= 1_000_000)
            return (number / 1_000_000f).ToString("0.#") + "M";
        if (number >= 1_000)
            return (number / 1_000f).ToString("0.#") + "K";
        return number.ToString();
    }

    public string FormatNumber(float number)
    {
        if (number >= 1_000_000f)
            return (number / 1_000_000f).ToString("0.#") + "M";
        if (number >= 1_000f)
            return (number / 1_000f).ToString("0.#") + "K";
        return number.ToString("0.##");
    }
    public IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (pauseSystem.
                Pause == false)
            {
                Yokai();
            }
            yield return new WaitForSeconds(Time);
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
            
            yokaiManager.Power += Value/Time;
            print("Yokai Bought");
            print(Value/Time);
        }
    }



}
