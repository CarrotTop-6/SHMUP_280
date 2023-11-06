using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls teleporting enemy
//11/5/23
public class TeleportEnemy : BaseEnemy
{
    // Start the teleporting sequence
    private void Start()
    {
        StartCoroutine(Teleport());
    }

    //Teleport enemy every x seconds
    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(3);
        transform.position = new Vector2(Random.Range(-9.5f, 9.5f), Random.Range(19f, -16f));
        StartCoroutine(Teleport());
    }

    private void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
