using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGfx : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aIPath;
    public float scale = 1f;
    public string tag = "eagle";
    // Update is called once per frame
    void Update()
    {
        if (tag == "bat")
        {
            if (aIPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(scale, scale, scale);
            }
            else if (aIPath.desiredVelocity.x <= -0.01f)
            {

                transform.localScale = new Vector3(-scale, scale, scale);
            }
        }

        if (tag == "eagle")
        {
            if (aIPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-scale, scale, scale);
            }
            else if (aIPath.desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(scale, scale, scale);
             
            }
        }

    }
}
