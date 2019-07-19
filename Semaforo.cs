using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Semaforo : MonoBehaviour
{
    [SerializeField]
    private GameObject Verde, Amarelo, Vermelho;
    public static bool go;
   // public AudioClip AuVerde, AuAmarelo, AuVermelho;


    private void OnEnable()
    {
        go = false;
        StartCoroutine(TimerSemaforo());
    }

    IEnumerator TimerSemaforo()
    {
        LuzVermelha();
        yield return new WaitForSeconds(1f);
        LuzAmarela();
        yield return new WaitForSeconds(1f);
        LuzVerde();
        yield return new WaitForSeconds(0.5f);
        go = true;
        gameObject.SetActive(false);

    }


    public void LuzVermelha()
    {
        Vermelho.SetActive(true);//
        Amarelo.SetActive(false); ;
        Verde.SetActive(false);
    }

    public void LuzAmarela()
    {
        Vermelho.SetActive(false);
        Amarelo.SetActive(true); ;//
        Verde.SetActive(false);
    }

    public void LuzVerde()
    {
        Vermelho.SetActive(false);
        Amarelo.SetActive(false);
        Verde.SetActive(true); ;//
    }



}
