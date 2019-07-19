using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    public Text scoreLive, Bestscore;


    private void OnEnable()
    {
        Time.timeScale = 0f;
        Semaforo.go = false;
        scoreLive.text = InGameUI.valueScore.ToString("F0").PadLeft(9, '0');

        if (InGameUI.valueScore > SaveScript.LoadSave())
        {
            SaveScript.SetSave(InGameUI.valueScore);
        }

        Bestscore.text =  SaveScript.LoadSave().ToString("F0").PadLeft(9, '0');
    }


    public void btnGameOver()
    {
        gameObject.SetActive(false);
        GameManager.MenuStart();

    }

    public void RestartGameOver()
    {
        gameObject.SetActive(false);
        GameManager.StartGame();
    }


}
