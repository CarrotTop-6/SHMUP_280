using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class SpawnerEnemy : BaseEnemy
{
    public GameObject missileEnemy;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        health = 2;
        StartCoroutine(SpawnInterval());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
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

    IEnumerator SpawnInterval()
    {
        yield return new WaitForSeconds(4);
        SpawnMissileEnemy();
    }

    private void SpawnMissileEnemy()
    {
        Instantiate(missileEnemy, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
    }
}
