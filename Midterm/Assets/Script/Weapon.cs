using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject ability1;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {    
            Ability1();
        }
    }

    void Ability1()
    {
        animator.SetTrigger("Ability1");
        Instantiate(ability1, firePoint.position, firePoint.rotation);
    }
}
