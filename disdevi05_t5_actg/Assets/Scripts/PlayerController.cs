using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D  myRigidbody2D;
    private float horizontal;
    public float velocidad;
    public float fuerzaSalto;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.W)){
            Jump();
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * velocidad, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void Jump(){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto);
    }
}
