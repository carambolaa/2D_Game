using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] Animator animator;

    [SerializeField] SpriteRenderer spriteRenderer;
    public int playerHP = 3;

    bool isInvincible;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
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

   


}
