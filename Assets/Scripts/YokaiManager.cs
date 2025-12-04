using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YokaiManager : MonoBehaviour
{
    public int yokaiTotalNumber;
    public TextMeshProUGUI yokaiText;
    public List<YokaiScript> yokais;

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
