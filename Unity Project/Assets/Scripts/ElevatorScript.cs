using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform player;
    public Transform elevatorSwitch;
    public Transform upperPos;
    public Transform downPos;
    public float speed;
    public Animator animator;
    bool isElevatorDown;

    private void Start()
    {

        speed = 2f;
    }

    private void Update()
    {
        StartElevator();
    }

    void StartElevator()
    {
       
        if (Vector2.Distance(player.position, elevatorSwitch.position)<1f && Input.GetKeyDown("e"))
        {
            animator.SetBool("isClicked", true);
            if (transform.position.y <= downPos.position.y)
            {
                isElevatorDown = true;
            }
            else if(transform.position.y >= upperPos.position.y)
            {
                isElevatorDown = false;
            }
        }
        if (isElevatorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
            animator.SetBool("isClicked", false);
        }
    }
}
