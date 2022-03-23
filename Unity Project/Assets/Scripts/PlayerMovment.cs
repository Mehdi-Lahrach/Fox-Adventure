using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public float jumpVelocity , jumpWaitTime;
    public float speed ;
    public float speedModifier;
    public float crouchSpeed;
    public KeyCode jumpKey;

    [SerializeField] Transform overHeadCheckCollider;
    const float overHeadCheckRadius = 0.2f;

    public Rigidbody2D rb;
    public LayerMask ground;
    public Collider2D footCollider;
    public Collider2D standingCollider;
    public Collider2D crouchCollider;

    public ParticleSystem dust;

    public Image fillBar;
    public float health;

    public Image[] lives;
    public int livesRemaining;
    public int livesCollected = 0;
    public float hurtForceX;
    public float hurtForceY;
    public float slowPower, stingPower;
    public float durationOfSting, durationOfSlowness;

    public Animator animator;

    public Vector3 respawnPoit;

    private float jumpWaitTimer;
    private bool isGrounded;
    private bool isCrouching;
    private bool isHurting;
    private bool isDead;
    private bool isStinged;
    private bool isSlowingDown;
    private bool canMove;
    private bool condition;
    private bool canKill;
    private bool canHurt;
   
    void Start()
    {
        respawnPoit = transform.position;
        canMove = true;
        condition = false;
        canKill = true;
        canHurt = true;
        isStinged = false;
        isSlowingDown = false;
    }
    

    
    void Update()
    {

        
        float move = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));
        if(canMove)
        isGrounded = footCollider.IsTouchingLayers(ground);
       
        if (canMove)
        rb.velocity = new Vector2(speed * move * Time.fixedDeltaTime, rb.velocity.y);
    
        if(move != 0f && canMove)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * move, transform.localScale.y);
        }

        if (Input.GetKeyDown(jumpKey) && !isCrouching)
        {
            if (isGrounded || jumpWaitTimer > 0f)
            {
                Jump();
            }
            
        }
        
        if(isGrounded)
        {
            animator.SetBool("isJumping", false);
            jumpWaitTimer = jumpWaitTime;
        }else
        {
            animator.SetBool("isJumping", true);
            if (jumpWaitTimer>0f)
            {
                jumpWaitTimer -= Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Crouch")) isCrouching = true;
        if (Input.GetButtonUp("Crouch")) isCrouching = false;

        Crouch(isCrouching);

        if(health < 100 && FindObjectOfType<ItemsDisplayer>().cherryCounter >= 5)
        {
            fillBar.fillAmount = 1;
            health = 100;
            FindObjectOfType<ItemsDisplayer>().cherryCounter -=5 ;
            FindObjectOfType<ItemsDisplayer>().DisplayCherry();
        }




        CheckForCollectedLives();



    }

  void CheckForCollectedLives()
    {
        if (livesCollected > 0 && livesRemaining <= 3)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (lives[i].enabled == false)
                {
                    lives[i].enabled = true;
                    livesCollected--;
                    livesRemaining++;
                }
                if (livesCollected <= 0)
                {
                    break;
                }
            }
        }
    }

    //getter
    public bool GetIsStinged()
    {
        return isStinged;
    }
    //setter
    public void SetIsStinged(bool value)
    {
        isStinged = value;
    }

    void Jump()
    {

        if (canMove)
        {
            CreateDust();
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity * Time.fixedDeltaTime);
        }
       
    }

    void Crouch(bool crouchFlag)
    {
        if (isGrounded)
        {
            standingCollider.enabled = !crouchFlag;
            crouchCollider.enabled = crouchFlag;
        }

        if (crouchFlag) speed = crouchSpeed;
        else speed = speedModifier;

        if (!crouchFlag)
        {
            if (Physics2D.OverlapCircle(overHeadCheckCollider.position, overHeadCheckRadius, ground))
                crouchFlag = true;
        }
      
        if (isHurting || isDead)
          crouchFlag = false;
        animator.SetBool("crouch", crouchFlag);
    }


    public void LoseHealth(int value)
    {
        
        //reduce the health
        health -= value;
        //refresh the UI 
        fillBar.fillAmount = health / 100;
   
    }
    public void LoseLife()
    {
        //decrease value of livesRemaining
        livesRemaining--;

        //hide one of life 
        lives[livesRemaining].enabled = false;

       
    }

    private void NockBack(float valueX , float valueY) {   rb.velocity = new Vector2(valueX, valueY);  }


    private void SetisHurting() {  
        isHurting = false; 
        animator.SetBool("hurt", isHurting);
        canHurt = true;
        canKill = true;
    }

    private void CreateDust() { dust.Play(); }

    private void setIsDead() {  isDead = false; animator.SetBool("isDead", isDead); }

    private void Respawn() { transform.position = respawnPoit; canKill = true; canHurt = true; }

    private void setCanMove() { canMove = true; }

    public void FreezPlayerMovement() { canMove = false; }

    private void ManageScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("enemy"))
        {
            if ((other.gameObject.GetComponent<EnemyID>().enemyPurpos.Equals("hurt") && health <= 25) || other.gameObject.GetComponent<EnemyID>().enemyPurpos.Equals("kill"))
            {
                if (canKill)
                {
                    canKill = false;
                    canHurt = false;
                    isGrounded = false;
                    LoseHealth(25);
                    condition = true;
                    canMove = false;
                    isDead = true;
                    animator.SetBool("isDead", isDead);
                    LoseLife();
                    if (livesRemaining == 0)
                    {
                        Invoke("ManageScene", .4f);
                    }
                    fillBar.fillAmount = 1;
                    health = 100;

                    Invoke("setIsDead", .5f);
                    Invoke("Respawn", .5f);
                }
                
            }
            else
            {
                if ((other.gameObject.GetComponent<EnemyID>().enemyPurpos.Equals("hurt") && health > 25))
                {
                    if (canHurt)
                    {
                        canHurt = false;
                        canKill = false;
                        condition = true;
                        canMove = false;

                        isHurting = true;
                        animator.SetBool("hurt", isHurting);

                        LoseHealth(25);

                        if (other.gameObject.transform.position.x > transform.position.x && isHurting)
                        {
                            NockBack(-hurtForceX, hurtForceY);
                        }
                        else if (other.gameObject.transform.position.x < transform.position.x && isHurting)
                        {
                            NockBack(hurtForceX, hurtForceY);

                        }
                        Invoke("SetisHurting", .5f);
                    }
                    
                }
            }
        }


        if (condition)
        {
            Invoke("setCanMove", .5f);
            condition = false;
        }
    }



   

    void RemoveStingEffect()
    {
        jumpVelocity += stingPower;
        isStinged = false;
    }
    void RemoveSlowEffect()
    {
        speedModifier += slowPower;
        isSlowingDown = false;
    }

    //belongs to Bee Effect Script
    public void Sting()
    {
        if (isStinged==false)
        {
            isStinged = true;
            jumpVelocity -= stingPower;
            Invoke("RemoveStingEffect", durationOfSting);  
        }

    }
    //belongs to slug Effect Script
    public void SlowDown()
    {
        if (isSlowingDown == false)
        {
            isSlowingDown = true;
            speedModifier -= slowPower;
            Invoke("RemoveSlowEffect", durationOfSlowness);
        }

    }

}
