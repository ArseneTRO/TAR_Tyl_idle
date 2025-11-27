using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class ScriptTestButton : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public int TestGold;
    public int Power;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Power = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gold()
    {
        TestGold += Power;
        goldText.text = TestGold.ToString("00");
    }
    

    public void echange()
    {
        if (TestGold > 10)
        {
            TestGold = TestGold - 10;
            goldText.text = TestGold.ToString("00");

            Power += 1;
        }


    }
}
