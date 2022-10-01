using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    public bool isTrackingPlayer = true;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        Vector3 destination = player.transform.position; ;
        Vector3 source = transform.position;

        Vector3 direction = destination - source;

        if(!isTrackingPlayer)
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
