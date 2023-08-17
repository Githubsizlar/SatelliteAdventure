using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        transform.position += direction * speed * Time.deltaTime;
        
        
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("isMoving",true);
            if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
            }
            if (horizontal > 0)
            {
                transform.rotation  = Quaternion.Euler(new Vector3(0,0,0));
            }
        }

        if (horizontal == 0 && vertical == 0)
        {
            anim.SetBool("isMoving",false);
        }
        //anim.SetBool("isMoving",false);
    }
}
