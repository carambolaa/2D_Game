using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] Animator animator;

    [SerializeField] SpriteRenderer spriteRenderer;
    public int playerHP = 3;
    public int maxHP = 3;

    public HealthBar healthBar;

    bool isInvincible;

    

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
        
    }
    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX, inputY) * speed;


        float scaleX = 1; 
        if (inputX > 0)
        {
            scaleX = -1;
        }
        else if (inputX < 0)
        {
            scaleX = 1;
        }

        else if (inputX == 0)
        {
            scaleX = transform.localScale.x;
        }

        transform.localScale = new Vector3(scaleX, 1, 1);

        bool isRunning = false;
        if(inputX != 0)
        {
            isRunning = true;
        }
        else if(inputX != 0)
        {
            isRunning = true;
        }

        animator.SetBool("IsRunning", isRunning);     
        
        
    }

    public bool OnDamage()
    {
        if(!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
            healthBar.SetHealth(playerHP);
            if(--playerHP <=0)
            {
                Destroy(gameObject);
            }
            return true;
        }
        return false;
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
        isInvincible = false;
    }




}
