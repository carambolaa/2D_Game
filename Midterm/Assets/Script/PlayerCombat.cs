using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack1();
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
            Debug.Log("We hit");
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
