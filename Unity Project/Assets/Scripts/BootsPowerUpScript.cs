using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsPowerUpScript : MonoBehaviour
{
    public float duration;
    public float powerAdded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           StartCoroutine( PowerUp(other));
            
        }
    }

    IEnumerator PowerUp(Collider2D player)
    {
        // increass jump velocety;
        player.GetComponent<PlayerMovment>().jumpVelocity += powerAdded;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        //wait
        yield return new WaitForSeconds(duration);
        player.GetComponent<PlayerMovment>().jumpVelocity -= powerAdded;
        Destroy(gameObject);
    }
}
