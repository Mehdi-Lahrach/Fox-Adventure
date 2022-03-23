using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossHP : MonoBehaviour
{
    public Image fillBar;
    public float bossHealth, timeToLoawdWinScene;

    public GameObject[] bees;
    public GameObject[] eagles;
    public GameObject [] spikeBoms;

    public GameObject [] gems;

    private Animator animator;
    private bool condition150 , condition100 , condition50;

    private void Start()
    {
        animator = GetComponent<Animator>();
        condition100 = true;
        condition150 = true;
        condition50 = true;
    }
    
    private void Update()
    {
       if(bossHealth <= 0)
       {
            GetComponent<BossAi>().speed = 0f;
            GetComponent<Patrole>().speed = 0f;
            animator.SetBool("isDead", true);
          
            Destroy(transform.gameObject, .3f);

            for (int i=0; i < gems.Length; i++)
            {
                gems[i].SetActive(true);
            }
            FindObjectOfType<MenuManager>().LoadWinSceneAfterSeconds();
        }
       else if(bossHealth <= 150 && condition150)
       {
            condition150 = false;
            for (int i = 0; i < 3; i++)
            {
                eagles[i].SetActive(true);
            }
            
        }
       else if (bossHealth <= 100 && condition100)
       {
            condition100 = false;
            for (int i = 0; i < 3; i++)
            {
                bees[i].SetActive(true);
            }
        }
       else if(bossHealth <= 50 && condition50)
        {
            condition50 = false;
            for (int i = 0; i < spikeBoms.Length; i++)
            {
                spikeBoms[i].SetActive(true);
            }
            for (int i = 3; i < bees.Length; i++)
            {
                bees[i].SetActive(true);
            }
            for (int i = 3; i < eagles.Length; i++)
            {
                eagles[i].SetActive(true);
            }
        }
    }

 
    public void LoseHealth(int value)
    {
        //reduce the health
        bossHealth -= value;
        //refresh the UI 
        fillBar.fillAmount = bossHealth / 200;
    }

}
