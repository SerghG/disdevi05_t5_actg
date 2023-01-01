using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaPerdido : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarNivel(int nEscena){
        Debug.Log("Escena seleccionada" + nEscena);
        SceneManager.LoadScene(nEscena);
    }
}
