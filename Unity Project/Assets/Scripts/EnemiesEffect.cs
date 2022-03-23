using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.parent.GetComponent<EnemyID>().enemyName.Equals("bee"))
            {
               other.GetComponent<PlayerMovment>().Sting();
            }
            if (transform.parent.GetComponent<EnemyID>().enemyName.Equals("slug"))
            {
                other.GetComponent<PlayerMovment>().SlowDown();
            }
            if (transform.parent.GetComponent<EnemyID>().enemyName.Equals("slow"))
            {
                other.GetComponent<PlayerMovment>().SlowDown();
            }

        }
    }
}
