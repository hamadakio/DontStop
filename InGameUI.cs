using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject ObjSemaforo, Score, btnMenu,MenuInGame;
    public Text txtScore;
    public static float valueScore;
    

    private void Update()
    {
        if (!ObjSemaforo.activeInHierarchy && gameObject.activeInHierarchy)
        {
            Gameplay(); 
        }

        valueScore += Time.deltaTime;

        txtScore.text = valueScore.ToString("F0").PadLeft(9,'0');
    }


    private void OnEnable()
    {
        Time.timeScale = 1f;
        ObjSemaforo.SetActive(true);
        Score.SetActive(false);
        btnMenu.SetActive(false);
        MenuInGame.SetActive(false);
        if (GameManager.InstancioadorInimigos.activeInHierarchy)
        {
            GameManager.InstancioadorInimigos.SetActive(false);
        }

        
        valueScore = 0f;
       
    }


    public void Gameplay()
    {
        Score.SetActive(true);
        btnMenu.SetActive(true);
        GameManager.InstancioadorInimigos.SetActive(true);
    }

    public void btnMenuGame()
    {
        Time.timeScale = 0.0f;
        btnMenu.SetActive(false);
        MenuInGame.SetActive(true);
    }

    public void btnContinuar()
    {
        Time.timeScale = 1.0f;
        btnMenu.SetActive(true);
        MenuInGame.SetActive(false);
    }
   
    public void btnReiniciar()
    {
        OnEnable();
    }

    public void btnSair()
    {
        GameManager.MenuStart();
    }
}
