using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Jack Bradford
//On player death, reload the scene
//11/5/23
public class ReloadScene : MonoBehaviour
{
    // check if health is <= 0
    void Update()
    {
        if(PlayerController.instance.health <= 0)
        {
            StartCoroutine(Respawn());
        }
    }

    //set a short timer before reloading scene
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
