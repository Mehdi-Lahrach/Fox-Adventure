using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool isShooting;

    public Transform shootPos;
    public GameObject star;
    public float shootTimer , shootSpeed;

    void Start()
    {
        isShooting = false;
    }

   
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
       int direction()
        {
            if (transform.localScale.x < 0f)
                 return -1;
            else
                 return +1;
        }
        isShooting = true;
        GameObject newStar =  Instantiate(star, shootPos.position, Quaternion.identity);

        newStar.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime , 0f);
       
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
