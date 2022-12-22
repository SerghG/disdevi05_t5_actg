using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;
    private bool perdido = false;

    void Update()
    {
            vidaActual -= Time.deltaTime * 10; 
            barraDeVida.fillAmount = vidaActual / vidaMaxima;
            /*
            if(vidaActual < 25){
                barraDeVida.color = Color.red;
            }
            */
            if(vidaActual <= 0 && perdido == false){
                Debug.Log("Has perdido.");
                perdido = true;
            }
    }

    public void addTiempoPila(){
        vidaActual = vidaActual + 20;
    }

    public void restaTiempo(float tiempoEliminar){
        vidaActual = vidaActual - tiempoEliminar;
    }
}
