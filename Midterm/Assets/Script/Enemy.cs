using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    [SerializeField] float speed = 1f;
    public bool isTrackingPlayer = true;
    GameObject player;

    public int maxHp = 100;
    public int currentHp;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHp = maxHp;
    }

    public void TakeDamage(int damge)
    {
        currentHp -= damge;

        animator.SetTrigger("TakeHit");
            
        if(currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Die");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        Invoke("DestroySelf", 3);

    }

    void DestroySelf()
    {
        Destroy(this.gameObject);
    }

        
    
    void Update()
    {
        if(player != null)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;

            Vector3 direction = destination - source;

            if (!isTrackingPlayer)
            {
                direction = new Vector3(1, 0, 0);
            }

            direction.Normalize();
            transform.position += direction * Time.deltaTime * speed;

            float scaleX = 1;
            if (direction.x > 0)
            {
                scaleX = -1;
            }
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player player = collision.GetComponent<Player>();
        if(player.OnDamage())
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }




}
