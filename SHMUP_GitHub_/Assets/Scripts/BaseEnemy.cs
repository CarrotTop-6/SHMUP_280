using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float powerupDropChance;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }

}
