using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHp : MonoBehaviour
{
    public float enemyHP;
    private float currentHP;


    public Animator animator;
    void Start()
    {
        currentHP = enemyHP;
    }


    void Update()
    {
        if (currentHP <= 0)
        {
           
            transform.parent.GetComponent<AIPatroleSpider>().speed = 0;
            animator.SetBool("isDead", true);
            Destroy(transform.parent.gameObject, .3f);
        }
    }
    public void takeDamage(float damage)
    {
        currentHP -= damage;
    }
}
