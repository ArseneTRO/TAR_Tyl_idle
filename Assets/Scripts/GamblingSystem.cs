using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GamblingSystem : MonoBehaviour
{
    public int Mise;
    public GameObject GamblingScreen;
    public bool actif;
    public int choice;
    public GameObject Warning;
    public GameObject Victory;
    public GameObject Defeat;
    public GameObject Results;
    public GameObject MoneyProblem;
    public int setVictoire;
    public GoldButtonScript GoldAmount;
    public PauseSystem PauseSystem;
    public TextMeshProUGUI MiseActuelle;
    public TextMeshProUGUI ChoixActuel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        choice = 0;
        actif = false;
        GamblingScreen.SetActive(false);
        Victory.SetActive(false);
        Defeat.SetActive(false);
        Results.SetActive(false);
        MoneyProblem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (choice == 0)
        {
            ChoixActuel.text = "Non Définit";
        }
        if (choice == 1)
        {
            ChoixActuel.text = "Rouge";
        }
        if (choice == 2)
        {
            ChoixActuel.text = "Noir";
        }
        if (choice == 3)
        {
            ChoixActuel.text = "Vert";
        }
        MiseActuelle.text = Mise.ToString("00");

        if (choice == 0)
        {
            Warning.SetActive(true);
        }
        else
        {
            Warning.SetActive(false);
        }

    }



    public void StartGambling()
    {
        actif = !actif;
        GamblingScreen.SetActive(actif);
        PauseSystem.Pause = true;
        MoneyProblem.SetActive(false);
    }

    public void StopGambling()
    {
        actif = !actif;
        GamblingScreen.SetActive(actif);
        PauseSystem.Pause = false;
    }
    public void ChooseColor(int i)
    {
        choice = i;
    }
  
    int randomChoice;

    public void CloseResults()
    {
        Victory.SetActive(false);
        Defeat.SetActive(false);
        Results.SetActive(false);
    }


    public void Convertir(string MiseBrut)
    {
        Mise = int.Parse(MiseBrut);
    }

    public void StartRoulette()
    {
        Defeat.SetActive(false);
        Victory.SetActive(false);
        if (Mise <= GoldAmount.Wallet)
        {
            Results.SetActive(true);

            GoldAmount.Wallet -= Mise;
            
            randomChoice = Random.Range(0, 100)+1;
            if(randomChoice%2 ==0)
            {
                setVictoire = 1;
            }
            else
            {
                if(randomChoice ==35)
                    {
                        setVictoire = 3;
                    }
                else
                { 
                    setVictoire = 2; 
                }
                
            }

            if(choice == setVictoire)
            {
                Victory.SetActive(true);
                if(setVictoire == 3)
                {
                    GoldAmount.Wallet += Mise * 35;
                }
                else
                {
                    GoldAmount.Wallet += Mise * 2;
                }
            }
            else
            {
                Defeat.SetActive(true);
            }
        }
        else
        {
            MoneyProblem.SetActive(true);
            Mise = 0;
        }
    }
}
