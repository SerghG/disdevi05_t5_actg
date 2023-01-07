using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoEmisor : MonoBehaviour
{
    // Este script hace referencia al objeto que emite sonido. Por ejemplo se lo asignariamos a una
    // moneda que emitiria sonido al ser recogida.
    public AudioClip sonido;
    public AudioClip musica;
    public AudioClip musica2;

    private void Update()
    {
        // Aqui incorporamos el script acerca de en que condiciones se emite el sonido
        // por ejemplo al detonar un trigger.

        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioController.instance.PlaySFX(sonido);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioController.instance.ChangeMusic(musica);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioController.instance.ChangeMusic(musica2);
        }
    }
}
