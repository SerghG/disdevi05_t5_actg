using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarPartidas : MonoBehaviour
{
    public void CargarNivel() {
        SceneManager.LoadScene(1);
    }

    public void CargarPantallaPrincipal() {
        SceneManager.LoadScene(4);
    }

     public void CargarPantallaControles() {
        SceneManager.LoadScene(5);
    }

    public void SalirJuego() {
        Application.Quit();
    }
}
