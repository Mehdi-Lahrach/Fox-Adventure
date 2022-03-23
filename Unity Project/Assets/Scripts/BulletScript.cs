using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float dieTime;
    public GameObject dieEffect;
    public float damageToHitEnemy;
    public int damageToHitBoss;
    public string bulletType = " ";
    private bool condition;
    
    void Start()
    {
        StartCoroutine(Timer());
        condition = true;
    }

   
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(bulletType != "star")
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
            Die();
        }
        else
        {
            if (other.gameObject.CompareTag("enemy") && condition)
            {
                condition = false;
              
                if(other.gameObject.GetComponent<EnemyID>().enemyName.Equals("slug") 
                    || other.gameObject.GetComponent<EnemyID>().enemyName.Equals("bee") ||
                    other.gameObject.GetComponent<EnemyID>().enemyName.Equals("plant"))
                {
                        other.gameObject.GetComponentInChildren<EnemyHP>().TakeDamage(damageToHitEnemy);
                        Instantiate(dieEffect, transform.position, Quaternion.identity);
                        Die();
                                 
                }
                else if (other.gameObject.GetComponent<EnemyID>().enemyName.Equals("boss"))
                {
                        other.gameObject.GetComponent<BossHP>().LoseHealth(damageToHitBoss);
                        Instantiate(dieEffect, transform.position, Quaternion.identity);
                        Die();   
                }
                else
                {
                    Instantiate(dieEffect, transform.position, Quaternion.identity);
                    Die();
                }
    
                Invoke("SetCondition", .3f);
            }
            else
            {
                Instantiate(dieEffect, transform.position, Quaternion.identity);
                Die();
            }
        }
           
        
    }
    void SetCondition()
    {
        condition = true;
    }
    private void Die()
    {
        if(dieEffect != null)
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
 
}
