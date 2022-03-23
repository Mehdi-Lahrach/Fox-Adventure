using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> wayPoint;
    public float speed;
    public int target;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoint[target].position, speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (transform.position == wayPoint[target].position)
        {
            if (target == wayPoint.Count - 1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }
    }
}
