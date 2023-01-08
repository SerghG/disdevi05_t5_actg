using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarPartidas : MonoBehaviour
{
    public void CargarNivel() {
        SceneManager.LoadScene(1);
    }

    public void CargarNivel1() {
        SceneManager.LoadScene(1);
    }

    public void CargarNivel2() {
        SceneManager.LoadScene(2);
    }

    public void PantallaPerdido() {
        SceneManager.LoadScene(0);
    }

    public void PantallaPrincipal() {
        SceneManager.LoadScene(4);
    }

    public void PantallaControles() {
        SceneManager.LoadScene(5);
    }

    public void SalirJuego(){
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
