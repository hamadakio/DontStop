using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStartUI : MonoBehaviour
{

    public GameObject Inicio, Creditos, SelecionarCarroeTutorial,Rank;
    public static int escolha;
    public Text RankScore;

    private void Awake()
    {
        Inicio.SetActive(true);
        Creditos.SetActive(false);
        Rank.SetActive(false);
        SelecionarCarroeTutorial.SetActive(false);
        escolha = 0;
    }



    private void OnEnable()
    {
        Time.timeScale = 1f;
        Inicio.SetActive(true);
        Creditos.SetActive(false);
        Rank.SetActive(false);
        SelecionarCarroeTutorial.SetActive(false);
        escolha = 0;

    }

    //Botoes

    public void AbrirCreditos()
    {
        Inicio.SetActive(false);
        Creditos.SetActive(true);
        SelecionarCarroeTutorial.SetActive(false);
        Rank.SetActive(false);
    }

    public void VoltarCreditos()
    {
        Inicio.SetActive(true);
        Creditos.SetActive(false);
        SelecionarCarroeTutorial.SetActive(false);
        Rank.SetActive(false);
    }

    public void AbrirRank()
    {
        Inicio.SetActive(false);
        Creditos.SetActive(false);
        SelecionarCarroeTutorial.SetActive(false);
        Rank.SetActive(true);
        RankScore.text = GameManager.BestScore.ToString("F0").PadLeft(9, '0');
    }

    public void VoltarRank()
    {
        Inicio.SetActive(true);
        Creditos.SetActive(false);
        SelecionarCarroeTutorial.SetActive(false);
        Rank.SetActive(false);
    }

    public void PlayBtn()
    {
        Inicio.SetActive(false);
        Creditos.SetActive(false);
        SelecionarCarroeTutorial.SetActive(true);
        Rank.SetActive(false);

    }

    public void Carro1()
    {
        escolha = 1;
        GameManager.CarroEscolhido();
        ExitMenuInicial();
    }

    public void Carro2()
    {
        escolha = 2;
        GameManager.CarroEscolhido();
        ExitMenuInicial();
    }

    private void ExitMenuInicial()
    {
        Inicio.SetActive(true);
        Creditos.SetActive(false);
        Rank.SetActive(false);
        SelecionarCarroeTutorial.SetActive(false);
        GameManager.StartGame();
    }
}
