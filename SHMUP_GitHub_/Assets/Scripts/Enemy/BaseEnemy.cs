using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float powerupDropChance;
    public Rigidbody rb;
    public GameObject blasterPU;
    public GameObject spreadPU;
    public GameObject shieldPU;
    public int spawnChance;
    

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet");
            health = -1;
            if(health <= 0)
            {
                Debug.Log("Destroy");
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Bottom")
        {
            Debug.Log("Bottom");
            transform.position = new Vector3(transform.position.x, 18, 0);
        }
    }

}
