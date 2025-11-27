using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestGrandMere : MonoBehaviour
{
    public TextMeshProUGUI GMText;
    public int YK;
    public ScriptTestButton GoldAmount;
    public GameObject go;
    public bool Pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MyCoroutine());
        YK = 0;

        Pause = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (Pause == false)
        {
            print("C'EST PAUSE!");
        }
        if (Pause == true)
        {
            print("C'EST PAAS PAUSE!");
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
            if(Pause == false)
            {
                Yokai();
            }
            yield return new WaitForSeconds(3);
        }
    }
    public void Yokai()
    { 
        GoldAmount.TestGold += 1 * YK;
        GMText.text = YK.ToString("00");
        GoldAmount.goldText.text = GoldAmount.TestGold.ToString("00");
    }

    
    


    public void AcheterGM()
    {
        if (GoldAmount.TestGold >= 10)
        {
            GoldAmount.TestGold -= 10;
            GoldAmount.goldText.text = GoldAmount.TestGold.ToString("00");

            YK += 1;
            GMText.text = YK.ToString("00");
        }
    }



}
