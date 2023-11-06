using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls all bullet projectile
//10/24/23
public class BulletController : MonoBehaviour
{
    int speed = 15;
    public Rigidbody rb;



    // Move bullet upwards
    void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }

    //Collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Enemy");
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Top")
        {
            Destroy(gameObject);
        }
    }
}
