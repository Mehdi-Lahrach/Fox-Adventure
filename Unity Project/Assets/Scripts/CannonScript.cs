using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    public Transform LineOfSight , shootPos;
    public float range , timeBetwenShoots, shootSpeed ;
    public GameObject bullet;
    public GameObject cannonSmoke;
    private bool isShooting;
    void Start()
    {
        isShooting = false;
    }

    
    void Update()
    {
        if (CanSeePlayer(range) && !isShooting){
            Instantiate(cannonSmoke, shootPos.position, Quaternion.identity);
            StartCoroutine(Shoot());
        }
    }




    bool CanSeePlayer(float distance)
    {   
        Vector2 endPos = LineOfSight.position + Vector3.right * distance;

        RaycastHit2D hit2D = Physics2D.Linecast(LineOfSight.position, endPos);

        if(hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
               return true;
            }
            else
            {
                return false;
            }
        }
        Debug.DrawLine(LineOfSight.position, endPos, Color.blue);
        return false;
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);


        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);

        yield return new WaitForSeconds(timeBetwenShoots);

        isShooting = false;
    }
}
