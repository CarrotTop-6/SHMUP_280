using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls the bouncing enemy
//11/30/23

public class BouncingEnemy : BaseEnemy
{
    private Vector2 move;
    private float lastY;

    // Start the bounce in a random direction
    void Start()
    {
        speed = 5;
        health = 1;
        int leftOrRight = Random.Range(1, 3);
        if(leftOrRight == 1)
        {
            move = Vector2.down + Vector2.left;
        }
        else
        {
            move = Vector2.down + Vector2.right;
        }
    }

    // Move the set direction
    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }


    //On collision, switch bounce direction
    protected void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (other.gameObject.tag == "SideWall")
        {
            move.x *= -1;
        }

        if (other.gameObject.tag == "Enemy")
        {
            move.x *= -1;
        }
    }
}
