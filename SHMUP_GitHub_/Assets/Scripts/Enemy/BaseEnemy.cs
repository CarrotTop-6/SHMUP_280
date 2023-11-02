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
    private int powerUpToSpawn;
    

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Debug.Log("Bullet");
            health = -1;
            if(health <= 0)
            {
                spawnChance = Random.Range(0, 1);
                Debug.Log(spawnChance);
                if(spawnChance == 0)
                {
                    Debug.Log("PowerUp");
                    powerUpToSpawn = Random.Range(1, 4);
                    if(powerUpToSpawn == 1)
                    {
                        Debug.Log("Blaster");
                        Instantiate(blasterPU, transform.position, Quaternion.identity);
                    }
                    else if(powerUpToSpawn == 2)
                    {
                        Debug.Log("Spread");
                        Instantiate(spreadPU, transform.position, Quaternion.identity);
                    }
                    else if(powerUpToSpawn == 3)
                    {
                        Debug.Log("Shield");
                        Instantiate(shieldPU, transform.position, Quaternion.identity);
                    }

                }
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Bottom")
        {
            //Debug.Log("Bottom");
            transform.position = new Vector3(transform.position.x, 18, 0);
        }
    }
}
