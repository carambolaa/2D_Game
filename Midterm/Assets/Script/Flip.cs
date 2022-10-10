using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

       
        if (inputX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }



    }
}
