using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls the missile enemy
//11/3/23
public class MissileEnemy : BaseEnemy
{
    Vector2 moveDirection;
    Transform target;

    // set the player as the target, and set the speed
    void Start()
    {
        speed = 15;
        target = GameObject.Find("Player").transform;
    }

    //  Set the direction the player is in
    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            moveDirection = direction;
        }  
    }

    //Move to the player
    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
    }

    //Collisions
    private void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}