using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class CarroScript : MonoBehaviour
{
    public static Vector3 position;
    public static float aceleration;

    void FixedUpdate()
    {
        if (Semaforo.go)
        {
            CarroControler();
            transform.position = position;
        }

       
    }

    public static Vector3 CarroControler()
    {
        //posicao x recebe o valor do acelerometro 
        position.x += Input.acceleration.x * (GameManager.VelocidadeGame*Time.deltaTime);
        Debug.Log(aceleration = Input.acceleration.x);
        //define um limite, pega um valor depois o min e maximo (value,min,max)
        position.x = Mathf.Clamp(position.x, -1.40f, 1.40f);
        //Define as posicoes do vetor (x,y,z) = x-tratado acima , y-posicao fixa do carro , z-profundidade fixa.
        position = new Vector3(position.x, -3f, 0f);

        return position;
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cone")
        {
            GameManager.SGameOver();
        }   
    }



}
