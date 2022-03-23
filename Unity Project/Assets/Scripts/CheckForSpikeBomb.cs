using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSpikeBomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("spikebomb"))
        {
            transform.parent.GetComponent<MaceScript>().canDrop = false;
        }
        else
            transform.parent.GetComponent<MaceScript>().canDrop = true;

    }
  
}
