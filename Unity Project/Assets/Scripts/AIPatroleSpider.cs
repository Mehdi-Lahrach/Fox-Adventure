using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatroleSpider : MonoBehaviour
{
    [HideInInspector]
    public bool mustPetrol;
    private bool mustTurn;

    public Rigidbody2D rb;
    public float speed;
    public Transform groundCheckPos;
    public LayerMask groundlayer;
    public Collider2D bodyCollider;

    public Transform LineOfSight, shootPos, player;
    public float range, timeBetwenShoots, shootSpeed;
    public GameObject bullet;
    public Animator animator;

    private bool canShoot;
    private float distToPlayer;
    void Start()
    {
        mustPetrol = true;
        canShoot = true;
        animator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (mustPetrol)
        {
            Patrol();
        }
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= range)
        {
            if (!(player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0))
            {
                Flip();
            }
                mustPetrol = false;
                rb.velocity = Vector2.zero;
                animator.SetBool("isShooting", true);
               if(canShoot)
                StartCoroutine(Shoot()); 
        }
        else
        {
            animator.SetBool("isShooting", false);
            mustPetrol = true;
        }

    }

    private void FixedUpdate()
    {
        if (mustPetrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundlayer);
        }
    }

    private void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundlayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPetrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPetrol = true;
    }

   
    IEnumerator Shoot()
    {
        canShoot = false;
       
        yield return new WaitForSeconds(timeBetwenShoots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);


        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);


        canShoot = true;
    }
}
