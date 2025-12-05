using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YokaiManager : MonoBehaviour
{
    public int yokaiTotalNumber;
    public TextMeshProUGUI yokaiText;
    public List<YokaiScript> yokais;
    public GoldButtonScript GoldAmount;

    void Update()
    {
        yokaiTotalNumber = 0;
        foreach (var y in yokais)
        {
            yokaiTotalNumber += y.YK;
        }

        yokaiText.text = yokaiTotalNumber.ToString();


        
    }


}
