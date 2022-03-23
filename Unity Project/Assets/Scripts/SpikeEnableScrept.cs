using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnableScrept : MonoBehaviour
{
    public GameObject spikes;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spikes.SetActive(true);
        }
    }
}
