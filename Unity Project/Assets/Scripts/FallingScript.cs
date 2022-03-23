using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    public float range;
    public GameObject dieEffect;
    private  bool isFalling = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;

        if (isFalling == false)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, range);

            Debug.DrawRay(transform.position, Vector2.down * range, Color.red);

            if(hit2D.transform != null)
            {
                if (hit2D.transform.CompareTag("Player"))
                {
                    rb.gravityScale = 10;
                    isFalling = true;
                }
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy") == false)
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
            Die();
        }
    }

    private void Die()
    {
        if (dieEffect != null)
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
