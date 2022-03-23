using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPicker : MonoBehaviour
{
    public Animator animator;
    private bool condition; 
    private void Start()
    {
        animator = GetComponent<Animator>();
        condition = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("picker") && condition)
        {
            condition = false;
            if (gameObject.CompareTag("gem")) 
            {
                animator.SetBool("isPicked", true);
                Destroy(gameObject, .3f);

                //cool methode 
                FindObjectOfType<ItemsDisplayer>().gemsCounter++;
                FindObjectOfType<ItemsDisplayer>().DisplayGems();
            }
            if (gameObject.CompareTag("cherry"))
            {
                animator.SetBool("isPicked", true);
                Destroy(gameObject, .3f);

                //cool methode 
                FindObjectOfType<ItemsDisplayer>().cherryCounter++;
                FindObjectOfType<ItemsDisplayer>().DisplayCherry();
            }
            if (gameObject.CompareTag("key"))
            {
                animator.SetBool("isPicked", true);
                Destroy(gameObject, .3f);

                //cool methode 
                FindObjectOfType<ItemsDisplayer>().keyCounter++;
                FindObjectOfType<ItemsDisplayer>().DisplayKey();
            }
            if (gameObject.CompareTag("heart"))
            {
                animator.SetBool("isPicked", true);
                Destroy(gameObject, .3f);

                FindObjectOfType<PlayerMovment>().livesCollected++;
            }
            if (gameObject.CompareTag("star"))
            {
                FindObjectOfType<PlayerShoot>().enabled = true;
                animator.SetBool("isPicked", true);
                Destroy(gameObject, .3f); 
            }
        }
        
    }

   
   
   

}
