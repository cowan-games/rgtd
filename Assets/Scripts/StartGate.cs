using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    public float timeBetweenWavesSeconds = 5.0f;
    public float timeBetweenSpawnsSeconds = 0.1f;
    public Waypoint firstWaypoint;
    public Wave[] waves;
    private int currentWaveIndex = 0;
    private int currentSpawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (firstWaypoint == null || waves == null) return;

        InvokeRepeating("SpawnCurrentWaveEnemy", timeBetweenWavesSeconds, timeBetweenSpawnsSeconds);
    }

    void SpawnCurrentWaveEnemy()
    {
        GameObject instantiated = Instantiate(waves[currentWaveIndex].enemyPrefab, transform.position, Quaternion.identity);
        Enemy enemy = instantiated.GetComponent<Enemy>();
        enemy.targetObject = firstWaypoint.gameObject;
        currentSpawnCount += 1;

        if (currentSpawnCount != waves[currentWaveIndex].amount) return;

        currentWaveIndex += 1;
        currentSpawnCount = 0;
        CancelInvoke();

        if (currentWaveIndex < waves.Length)
        {
            InvokeRepeating("SpawnCurrentWaveEnemy", timeBetweenWavesSeconds, timeBetweenSpawnsSeconds);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firstWaypoint == null) return;

    }
}
