using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack1();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
       

        if(Input.GetKeyDown(KeyCode.E))
        {
            Attack2();
        }

        
    }

    void Attack1()
    {
        animator.SetTrigger("Attack");     

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enmey in hitEnemies)
        {
            enmey.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void Attack2()
    {
        animator.SetTrigger("Attack2");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enmey in hitEnemies)
        {
            Debug.Log("We hit");
        }
    }



    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
