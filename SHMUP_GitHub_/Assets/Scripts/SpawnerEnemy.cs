using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
    }

    private new void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SideWall")
        {
            speed *= -1;
            //transform.Translate(new Vector2(transform.position.x, transform.position.y - 3));
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
            speed *= -1;
        }
    }
}
