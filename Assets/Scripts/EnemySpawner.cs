using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints;
    public List<int> enemyCounts;

    [Range(0.1f,5)]public float spawnInterval = 2f;
    [Range(0.1f, 15f)] public float waveInterval = 10f;

    public int enemiesLeft;

    public UnityEvent onWaveStarted;
    public UnityEvent onWaveEnded;

    async void Start()
    {
        Random.seed = 100;

        foreach (var item in enemyCounts)
        {
            onWaveStarted.Invoke();
            enemiesLeft = item;
            while (enemiesLeft> 0)
            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesLeft--;
            }
            onWaveEnded.Invoke();

            await new WaitForSeconds(waveInterval);
        }

    }

    public void Spawn()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
