using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator animator;
    public GameObject item;
    public GameObject heart;
    private bool condition = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && condition)
        {
            OpenChest();
            condition = false;
        }
    }
    void OpenChest()
    {
        animator.SetBool("open", true);
        item.SetActive(true);
        if(heart != null)
        {
            heart.SetActive(true);
        }
    }
}
