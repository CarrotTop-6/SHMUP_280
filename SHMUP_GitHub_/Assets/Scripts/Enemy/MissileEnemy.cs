using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemy : BaseEnemy
{
    Vector2 moveDirection;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            moveDirection = direction;
        }  
    }

    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}