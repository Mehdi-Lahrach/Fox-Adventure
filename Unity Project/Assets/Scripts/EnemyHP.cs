using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyHP : MonoBehaviour
{
    public float enemyHP;
    private float currentHP;


    public Animator animator;
    void Start()
    {
        currentHP = enemyHP;
        animator = transform.parent.GetComponent<Animator>();
    }

    
    void Update()
    {
        if (currentHP <= 0)
        {
           if(transform.parent.GetComponent<EnemyID>().enemyAiType.Equals("patrol"))
            {
                transform.parent.GetComponent<Patrole>().speed = 0;
            }
               

           if (transform.parent.GetComponent<EnemyID>().enemyAiType.Equals("follow"))
                transform.parent.GetComponent<AIPath>().maxSpeed = 0;

            animator.SetBool("isDead", true);
            Destroy(transform.parent.gameObject,.3f);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
    }
}
