using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnyWalk : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));
        rb.velocity = new Vector2(speed * move * Time.fixedDeltaTime, rb.velocity.y);
        
        if (move != 0f)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * move, transform.localScale.y);
        }
    }
}
