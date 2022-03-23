using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBombScript : MonoBehaviour
{
    
    public GameObject hurtPlayer;
    public GameObject bombSprit;
    public Animator animator;

    private bool isDetected = false;

    private void Update()
    {
        if (isDetected)
        {
            bombSprit.GetComponent<SpriteRenderer>().enabled = false;
            animator.SetBool("expload", true);
            hurtPlayer.SetActive(true);
            Destroy(gameObject, .3f);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isDetected = true;
        }
    }
   
}
