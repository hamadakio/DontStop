using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLevelManager : MonoBehaviour
{
    [Header("Inimigos")]
    public GameObject Prefab1;
    private GameObject InstanciadorObj, RecicleObj;

    [Header("Numero de Inimigos")]
    [Range(1, 10)]
    public int NumeroInimigos1;


    private float LimiteEsquerda, LimiteDireita;
    private Vector3 StartPosition;
    private List<GameObject> Objetos = new List<GameObject>();

    private float timer, delay;

    private void Awake()
    {
        InstanciadorObj = GameObject.Find("Instanciador");
        RecicleObj = GameObject.Find("Recicler");

        StartPosition = InstanciadorObj.transform.position;
        LimiteEsquerda = InstanciadorObj.transform.position.x - (InstanciadorObj.transform.localScale.x / 2);
        LimiteDireita = InstanciadorObj.transform.position.x + (InstanciadorObj.transform.localScale.x / 2);
        delay = GameManager.VelocidadeGame;
    }

    private void OnEnable()
    {
        Objetos.Clear();

        StartCoroutine(Instanciador(Prefab1));

        foreach (var item in Objetos)
        {
            item.SetActive(true);
        }

    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            timer = delay* Random.Range(1.8f,2.8f);
            Recicle(RecicleObj);
        }
    }


    IEnumerator Instanciador(GameObject Iobj)
    {
        int aux = 0;

        if (aux <= NumeroInimigos1)
        {
            for (int i = 0; i < NumeroInimigos1; i++)
            {
                Objetos.Add(Instantiate(Iobj, Limites(LimiteEsquerda, LimiteDireita, StartPosition), Quaternion.identity));
                aux++;
                yield return new WaitForSeconds(1f);
            }
        }

    }

    public void Recicle(GameObject recicle)
    {
        foreach (var item in Objetos)
        {
            if (item.transform.position.y <= recicle.transform.position.y)
            {
                item.transform.position = Limites(LimiteEsquerda, LimiteDireita, StartPosition);
            }
        }

    }

    private Vector3 Limites(float limEsquerda, float limDireita, Vector3 position)
    {
        float X = 0;

        X = Random.Range(limEsquerda, limDireita);

        position = new Vector3(X, position.y, position.z);

        return position;

    }

    private void OnDisable()
    {
        foreach (var item in Objetos)
        {
            item.SetActive(false);
        }

    }
}
