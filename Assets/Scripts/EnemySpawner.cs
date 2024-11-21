using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public float timeBetweenSpawns;
    float nextSpawnTime;
    public float progressiveDifficultyIncreaseTime;
    public float minTimeBetweenSpawns;
    public float difficultyIncrease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime){
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }

        if(Time.time > progressiveDifficultyIncreaseTime){
            timeBetweenSpawns = timeBetweenSpawns > minTimeBetweenSpawns ? timeBetweenSpawns - difficultyIncrease : minTimeBetweenSpawns;
        }
    }
}
