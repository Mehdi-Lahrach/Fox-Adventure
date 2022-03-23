using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{

    public Transform LineOfSight;
    public float range , timeBtweenAttacks;

    private Animator animator;
    private bool isAttacking;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isAttacking = false;
    }

    private void Update()
    {
        if (CanSeePlayer(range)&& !isAttacking)
        {
            StartCoroutine(Attack());
        }
        
    }

    bool CanSeePlayer(float distance)
    {
        Vector2 endPos = new Vector2();
        if (transform.localScale.x < 0f) { 
             endPos = LineOfSight.position + Vector3.right * distance;
        }
        else
        {
            endPos = LineOfSight.position + Vector3.left * distance;
        }
       

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
   IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(timeBtweenAttacks);
        animator.SetBool("attack", false);
        isAttacking = false;
    }
}
