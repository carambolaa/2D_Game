using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    
    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

}
