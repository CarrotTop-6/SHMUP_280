using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Sets the base power up data
//11/2/23
public class BasePowerUp : MonoBehaviour
{
    public Rigidbody rb;
    protected int timer;
    private int speed = 3;

    //Destroy on collision
    protected void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bottom")
        {
            Destroy(gameObject);
        }
    }

    //move down
    private void Update()
    {
        rb.velocity = new Vector2(0, -speed);
    }
}
