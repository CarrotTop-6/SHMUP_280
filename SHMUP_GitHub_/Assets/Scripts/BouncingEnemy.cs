using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : BaseEnemy
{
    private Vector2 move;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }

    private new void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SideWall")
        {
            move.x *= -1;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            move.x *= -1;
        }
        
        if (collision.gameObject.tag == "Bottom")
        {
            Debug.Log("Bottom");
            transform.position = new Vector3(transform.position.x, 18, 0);
        }


    }
}
