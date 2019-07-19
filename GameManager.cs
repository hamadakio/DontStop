using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //this object
    public static GameManager instance = null;

    public static GameObject C1, C2;

    public static float BestScore;

    //CanvasObjects
    public static GameObject MenuStartPanel, InGamePanel, GameOverPanel;

    //Global Values
    public static float VelocidadeGame;

    //States
    private bool MenuStartbool, GameOverbool;

    public bool testsemaforo;
    public static GameObject InstancioadorInimigos;

    void Awake()
    {
        //mantem o display sempre ligado durante a execucao;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //checa se ja tem uma instancia desse objeto na cena 
        if (instance == null)
        {   //senao ele seta esse como o objeto instanciado 
            instance = this;
        }
        //se ja exixtir uma instancia desse objeto e nao for esse objeto
        else if (instance != this)
        {
            //destroi esse objeto pra que nao haja conflito.
            Destroy(gameObject);
        }

        //Nao Destroi esse Objeto caso a cena seja Recarregada
        DontDestroyOnLoad(gameObject);


        MenuStartPanel = GameObject.Find("MenuStart");
        InGamePanel = GameObject.Find("InGame");
        GameOverPanel = GameObject.Find("GameOver");
        InstancioadorInimigos = GameObject.Find("Instanciador&Reciclador");
        C1 = GameObject.Find("Carro1");
        C2 = GameObject.Find("Carro2");

        

        MenuStart();
    }

    private void Update()
    {
        VelocidadeGame += Time.deltaTime * 0.3f;
        
        if (Input.GetKey(KeyCode.P))
        {
            SGameOver();
        }
    }


    //Funcoes Estado do Jogo
    public static void MenuStart()
    {
        Time.timeScale = 1f;
        MenuStartPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        InGamePanel.SetActive(false);
        C2.SetActive(true);
        C1.SetActive(true);
        InstancioadorInimigos.SetActive(false);
        CarroPossMenuStart(C1,C2);
        BestScore = SaveScript.LoadSave();
    }


    public static void StartGame()
    {
        MenuStartPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    public static void SGameOver()
    {
        GameOverPanel.SetActive(true);
        InGamePanel.SetActive(false);

    }

    public static void CarroEscolhido()
    {
        if (MenuStartUI.escolha == 1)
        {
            C2.SetActive(false);
        }
        else if (MenuStartUI.escolha == 2)
        {
            C1.SetActive(false);
        }
    }


    public static void CarroPossMenuStart(GameObject c1,GameObject c2)
    {
        c1.transform.position = new Vector3(1,-3,0);
        c2.transform.position = new Vector3(-1, -3, 0);
    }

}
