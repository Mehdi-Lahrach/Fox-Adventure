using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerPos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovment>().respawnPoit = transform.position;
        }
    }
}
