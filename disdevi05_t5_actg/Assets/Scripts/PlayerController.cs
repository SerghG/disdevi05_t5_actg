using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private SpriteRenderer mySprite;
    private float horizontal;
    public float velocidad;
    public float fuerzaSalto;
    public float fuerzaCaida;
    public LayerMask suelo;
    public bool enSuelo = false;
    public float longitudSuelo;
    public float gravedad = 1;
    public SonidoEmisor emisor;
    public GameObject Bala;
    private bool peticionSalto;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        enSuelo = Physics2D.Raycast(transform.position, Vector2.down, longitudSuelo, suelo);

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            mySprite.flipX = true;
        }

        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            mySprite.flipX = false;
        }
            
        else if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && enSuelo) {
            peticionSalto = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = new Vector2(horizontal * velocidad, myRigidbody2D.velocity.y);
        ModifyPhisics();

        if (peticionSalto) {
            Jump();
        }
    }

    private void ModifyPhisics(){
        if (enSuelo) {
            myRigidbody2D.drag = 0;
        }
        else {
            myRigidbody2D.gravityScale = gravedad;
            myRigidbody2D.drag = 0.6f;
            if (myRigidbody2D.velocity.y < 0) {
                myRigidbody2D.gravityScale = gravedad * fuerzaCaida;
            }
        }
    }

    private void Jump(){
        myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, 0);
        myRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

        peticionSalto = false;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudSuelo);
    }

    private void Disparar(){
        this.emisor.disparar();
        Instantiate(Bala, transform.position, transform.rotation);
    }
}
