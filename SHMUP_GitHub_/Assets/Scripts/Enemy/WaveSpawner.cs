using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Bradford
//Controls the wave spawner
//10/31/23
//https://www.youtube.com/watch?v=7T-MTo8Uaio

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currentWave;
    public int waveValue;

    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocation;
    private Vector3 spawnpos;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    public bool spawnerOn;

    // Start is called before the first frame update
    void Start()
    {
        //if spawner on, start the round
        if(spawnerOn)
        {
            GenerateWave();
        }
        
    }

    // Update is called once per frame
    //spawn in enemies from enemiesToSpawn list
    void FixedUpdate()
    {
        if(spawnTimer <= 0)
        { 
            if(enemiesToSpawn.Count > 0)
            {
                spawnpos = new Vector3(Random.Range(-5, 0), Random.Range(12, 18), 0);
                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnpos, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }

    //Generate the next wave
    public void GenerateWave()
    {
        waveValue = currentWave * 30;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; //gives a fixed time between each enemy
        waveTimer = waveDuration;
    }

    //Generate the list of enemies for the next wave
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue>0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue<= 0)
            {
                
                break;
            }
        } 
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
        StartCoroutine(NextWave());
    }

    //After the last wave is all spawned in, start the next wave
    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(waveDuration + 5);
        GenerateWave();
    }
}


//Creating enemies to spawn
[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
