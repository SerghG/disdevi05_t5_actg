using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkController : MonoBehaviour
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
    public bool turning = false;
    private float playerDistance;
    private GameObject player;
    private float timer;
    public GameObject bullet;
    public Transform bulletPosition;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        currentHealth = maxHealth;

        facingDirection = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!turning && !isAttacking) {
            groundDetected = Physics2D.Raycast(transform.position + (colliderOffset * facingDirection), Vector2.down, groundDistance, ground);
            wallDetected = Physics2D.Raycast(transform.position, (Vector2.right * facingDirection), wallDistance, wall);

            if ((!groundDetected || wallDetected)) {
                turning = true;
                Turn();
            }
            else {
                agent.velocity = new Vector2(movementSpeed * facingDirection, agent.velocity.y);
                //playerDistance = Vector2.Distance(transform.position, player.transform.position);
                //playerDistance = transform.position.x - player.transform.position.x;
            }
        }

        else if (isAttacking) {
            timer += Time.deltaTime;

            if (timer > 0.8) {
                timer = 0;
                Shoot();
            }
        }
    }

    private void Turn() {
        agent.velocity = new Vector2(0, 0);
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
        bulletPosition.transform.Rotate(0, 180, 0);
        StartCoroutine(Wait());
    }

    private void Attack() {
        animator.SetBool("Run", false);
        agent.velocity = new Vector2(0, 0);
        animator.SetBool("Attack", true);
    }

    private void Shoot() {
        if (facingDirection == 1) {
            Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        }
        else {
            Instantiate(bullet, bulletPosition.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + (colliderOffset * facingDirection), transform.position + (colliderOffset * facingDirection) + Vector3.down * groundDistance);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * facingDirection * wallDistance);
    }

    private IEnumerator Wait() {
        yield return new WaitForSecondsRealtime(1.5f);
        facingDirection *= -1;
        agent.transform.Rotate(0, 180, 0);
        turning = false;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            isAttacking = false;
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            isAttacking = true;
            Attack();
        }
    }
}
