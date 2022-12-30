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
        Debug.Log("Tiempo añadido");
    }

    public void restaTiempo(float tiempoEliminar){
        vidaActual = vidaActual - tiempoEliminar;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "BonusEnergia"){
            this.addTiempoPila();
        }
    }
}
