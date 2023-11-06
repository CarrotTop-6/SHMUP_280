using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls the falling enemy
//10/30/23
public class FallingEnemy : BaseEnemy
{
    public float dropRandomizer;
    public bool drop = false;

    // Start the drop timer
    void Start()
    {
        health = 1;
        speed = 1;
        StartCoroutine(DropTimer());
        
    }

    // Sets the enemy movement speed
    void Update()
    {
        rb.velocity = new Vector2(0, -speed);
    }

    //Wait for random seconds, then increase speed
    IEnumerator DropTimer()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 20.0f));
        
        drop = true;
        speed = 10;
        
    }
}
