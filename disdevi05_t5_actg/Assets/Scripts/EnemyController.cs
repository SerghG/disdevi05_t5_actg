using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D agent;
    private Animator animator;
    public float radarDistance;
    public float maxHealth = 100;
    private float currentHealth;
    public LayerMask ground;
    public LayerMask wall;
    public float groundDistance;
    public float wallDistance;
    public bool groundDetected;
    public bool wallDetected;
    private int facingDirection;
    public float movementSpeed;
    public Vector3 colliderOffset;
    private bool turning = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        currentHealth = maxHealth;

        facingDirection = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!turning){
            groundDetected = Physics2D.Raycast(transform.position + (colliderOffset * facingDirection), Vector2.down, groundDistance, ground);
            wallDetected = Physics2D.Raycast(transform.position, transform.right, wallDistance, wall);
        
            if((!groundDetected || wallDetected)) {
                turning = true;
                Turn();
            }
            else {
                agent.velocity = new Vector2(movementSpeed * facingDirection, agent.velocity.y);
                animator.SetBool("Run", true);
            }
        }
    }

    private void Turn() {
        agent.velocity = new Vector2(0, 0);
        animator.SetBool("Run", false);
        StartCoroutine(Wait());
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + (colliderOffset * facingDirection), transform.position - colliderOffset + Vector3.down * groundDistance);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * wallDistance);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * wallDistance);
    }

    private IEnumerator Wait() {
        yield return new WaitForSecondsRealtime(1.5f);
        facingDirection *= -1;
        agent.transform.Rotate(0, 180, 0);
        turning = false;
    }
}
