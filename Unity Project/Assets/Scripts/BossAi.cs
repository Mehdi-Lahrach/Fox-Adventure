using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public Transform LineOfSight, LineOfSightOfBehind, LineOfSightOfFront, shootPosFromHand, shootPosFromMouth,player;
    public float range, rangFromBehind, rangFromHead, timeBetwenShoots, shootSpeed, speed;
    public GameObject bullet;

    private Animator animator;
    private Rigidbody2D rb;
    private bool isShooting;

    private void Start()
    {
        isShooting = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (CanSeePlayer(range))
        {
            ChasePlayer();
            if (!isShooting)
            {
                StartCoroutine(Shoot(shootPosFromHand));
            }
        }
        else if (CanSeePlayerInFront(rangFromHead))
        {
            ChasePlayer();
            if (!isShooting)
            {
                StartCoroutine(Shoot(shootPosFromMouth));
            }
        }
        else if(CanSeePlayerFromBehind(rangFromBehind))
        {
            GetComponent<Patrole>().enabled = false;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            ChasePlayer();
        }
       
        else
        {
           // rb.velocity = Vector2.zero;
            GetComponent<Patrole>().enabled = true;
        }

        if((GetComponent<Patrole>().speed < 0f && transform.localScale.x < 0f )||( GetComponent<Patrole>().speed > 0f && transform.localScale.x > 0f))
        {
            GetComponent<Patrole>().speed *= -1f;
        }
       
    }

    int Direction()
    {
        if (transform.localScale.x < 0f)
            return -1;
        else
            return +1;
    }

    bool CanSeePlayer(float distance)
    {
        Vector2 endPos = LineOfSight.position + Vector3.left * distance * Direction();

        RaycastHit2D hit2D = Physics2D.Linecast(LineOfSight.position, endPos);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        Debug.DrawLine(LineOfSight.position, endPos, Color.blue);
        return false;
    }
    bool CanSeePlayerFromBehind(float distance)
    {
        Vector2 endPos = LineOfSightOfBehind.position + Vector3.right * distance * Direction();

        RaycastHit2D hit2D = Physics2D.Linecast(LineOfSightOfBehind.position, endPos);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        Debug.DrawLine(LineOfSightOfBehind.position, endPos, Color.yellow);
        return false;
    }
    bool CanSeePlayerInFront(float distance)
    {
        Vector2 endPos = LineOfSightOfFront.position + Vector3.left * distance * Direction();

        RaycastHit2D hit2D = Physics2D.Linecast(LineOfSightOfFront.position, endPos);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        Debug.DrawLine(LineOfSightOfFront.position, endPos, Color.blue);
        return false;
    }
    private void ChasePlayer()
    {
        GetComponent<Patrole>().enabled = false;
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
            
        }
        else if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, rb.velocity.y);
           
        }
        else
        {
            rb.velocity = Vector2.zero;
           
        }
    }
    IEnumerator Shoot(Transform shootPos)
    {
        
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Direction() *-1* Time.fixedDeltaTime, 0f);

        yield return new WaitForSeconds(timeBetwenShoots);
        isShooting = false;
    }

}
