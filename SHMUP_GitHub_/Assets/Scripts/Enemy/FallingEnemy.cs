using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : BaseEnemy
{
    public float dropRandomizer;
    public bool drop = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        speed = 1;
        StartCoroutine(DropTimer());
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -speed);
    }

    IEnumerator DropTimer()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 20.0f));
        
        drop = true;
        speed = 10;
        
    }
}
