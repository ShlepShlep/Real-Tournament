using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3[] positions;

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
        var randomPos = positions[Random.Range(0, positions.Length)];
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
}
