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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SideWall")
        {
            speed *= -1;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
            speed *= -1;
        }
    }
}
