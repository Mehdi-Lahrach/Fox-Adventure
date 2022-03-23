using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrole : MonoBehaviour
{
    [HideInInspector]
    public bool mustPetrol;
    private bool mustTurn;

    public Rigidbody2D rb;
    public float speed , range , speedModifire;
    public Transform groundCheckPos , LineOfSight;
    public LayerMask groundlayer;
    public Collider2D bodyCollider;
   
    void Start()
    {
        mustPetrol = true;
    }

     void Update()
    {
        if (mustPetrol)
        {
            Patrol();
        }
        if(GetComponent<EnemyID>().enemyName == "spider")
        {
            if (CanSeePlayer(range))
            {
               if(speed <0)
                {
                    speed = - speedModifire;
                }
               else 
                {
                    speed = speedModifire;
                }
            }
            else
            {
                if (speed < 0)
                {
                    speed = -150;
                }
                else 
                {
                    speed = 150;
                }
            }
          
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
}
