using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D myRigidBody;
    public float force;
    private Vector3 direction;
    private float rotation;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        direction = new Vector3(player.transform.position.x - transform.position.x, 0f, 0f);
        myRigidBody.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<GameController>().vidaActual -= 100;
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Suelo")) {
            Destroy(gameObject);
        }
    }
}
