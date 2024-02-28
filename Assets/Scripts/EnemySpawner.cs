using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        var randomPos = new Vector3(Random.Range(-4, 4), 1, Random.Range(-8, -6));
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
}
