using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CheckForPlayer : MonoBehaviour
{
    public Transform Player;
    public float range;

    private float distanceToPlayer;

    private void Start()
    {
        transform.GetComponent<AIPath>().canMove = false;
    }


    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, Player.position);

        if (distanceToPlayer <= range)
        {
            transform.GetComponent<AIPath>().canMove = true;
        }
        else{
            transform.GetComponent<AIPath>().canMove = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
