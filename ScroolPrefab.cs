using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroolPrefab : MonoBehaviour
{
    private BackgroudScrool Scrooler;

    [Range(0.1f,15f)]
    public float velocidadeScrool;

    public bool SomaVelocidade = false;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        Scrooler = new BackgroudScrool(velocidadeScrool,rend);
    }


    private void LateUpdate()
    {
        Scrooler.SetVelocity(velocidadeScrool, SomaVelocidade);
        Scrooler.Movescrool();
    }
}
