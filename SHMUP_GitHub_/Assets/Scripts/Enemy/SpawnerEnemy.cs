using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

//Jack Bradford
//Controls the Spawning Enemy
//11/1/23

public class SpawnerEnemy : BaseEnemy
{
    public GameObject missileEnemy;
    // Start the spawn interval timer
    void Start()
    {
        speed = 3;
        health = 2;
        StartCoroutine(SpawnInterval());
    }

    //  Movement
    void Update()
    {
        transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        //if collides with a sideall or enemy, reverse movement
        if (collision.gameObject.tag == "SideWall")
        {
            speed *= -1;
            //transform.Translate(new Vector2(transform.position.x, transform.position.y - 3));
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Enemy");
            speed *= -1;
        }
    }

    //Missile spawner timer
    IEnumerator SpawnInterval()
    {
        yield return new WaitForSeconds(4);
        SpawnMissileEnemy();
    }

    //Spawn missile enemy
    private void SpawnMissileEnemy()
    {
        Instantiate(missileEnemy, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
    }
}
