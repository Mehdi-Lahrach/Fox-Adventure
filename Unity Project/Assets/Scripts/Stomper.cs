using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public float damageToDeal;

    public float bounceForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemyhurtbox"))
        {
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal);
            rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
        if(other.gameObject.CompareTag("spiderhurtbox"))
        {
            other.gameObject.GetComponent<SpiderHp>().takeDamage(damageToDeal);
            rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }

}
