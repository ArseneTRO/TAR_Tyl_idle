using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YokaiManager : MonoBehaviour
{
    public List<YokaiScript> yokais;
    public GoldButtonScript GoldAmount;
    public TextMeshProUGUI PowerData;
    
    public float Power;

    void Start()
    {
        Power = 0;
    }
    void Update()
    {
        PowerData.text = $"PowerShop: {FormatNumber(Power)}/sec";

        
    }

        public string FormatNumber(float number)
    {
        if (number >= 1_000_000f)
            return (number / 1_000_000f).ToString("0.#") + "M";
        if (number >= 1_000f)
            return (number / 1_000f).ToString("0.#") + "K";
        return number.ToString("0.##");
    }


}
