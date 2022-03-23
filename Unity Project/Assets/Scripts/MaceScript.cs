using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceScript : MonoBehaviour
{
    public Transform player, bombDropper;
    public GameObject bomb;
    public float range, waitToDropBomb , speed;

    private Rigidbody2D rb;
    
    public bool canDrop;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
  
        canDrop = true;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
       
        if (distance < range)
        {
            ChasePlayer();
           // if (!isDropping && canDrop)
             //   StartCoroutine(DropBomb());
        }
        else
        {
            StopChasingPlayer();
        }
    }

    private void StopChasingPlayer()
    {
        rb.velocity = Vector2.zero;
        GetComponent<Patrole>().enabled = true;
    }

    private void ChasePlayer()
    {
        GetComponent<Patrole>().enabled = false;
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(speed* Time.fixedDeltaTime, rb.velocity.y);
          
        }
        else if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, rb.velocity.y);
          
        }  
    }
  
  
}
