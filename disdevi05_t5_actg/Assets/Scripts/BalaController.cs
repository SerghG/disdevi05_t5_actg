using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{

    [SerializeField] private float velocidad;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer > 10) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        /*if (other.gameObject.CompareTag("Trunk")) {
            other.gameObject.GetComponent<TrunkController>().currentHealth -= 35;
            if (other.gameObject.GetComponent<TrunkController>().currentHealth <= 0) {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Rino")) {
            other.gameObject.GetComponent<RinoController>().currentHealth -= 50;
            Destroy(gameObject);
            if (other.gameObject.GetComponent<RinoController>().currentHealth <= 0) {
                Debug.Log("Hola");
                Destroy(other.gameObject);
            }
        }*/
        if (other.gameObject.CompareTag("Suelo")) {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Rino")) {
            Destroy(gameObject);
        }
    }
}
