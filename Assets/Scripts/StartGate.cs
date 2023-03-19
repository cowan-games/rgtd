using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    public float TimeBetweenWavesSeconds = 5.0f;
    public float TimeBetweenSpawnsSeconds = 1f;
    public Waypoint FirstWaypoint;
    public Wave[] Waves;
    private int _currentWaveIndex = 0;
    private int _currentSpawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (FirstWaypoint == null || Waves == null) return;

        InvokeRepeating("SpawnCurrentWaveEnemy", 5, TimeBetweenSpawnsSeconds);
    }

    void SpawnCurrentWaveEnemy()
    {
        GameObject instantiated = Instantiate(Waves[_currentWaveIndex].EnemyPrefab, transform.position, Quaternion.identity);
        Enemy enemy = instantiated.GetComponent<Enemy>();
        enemy.TargetObject = FirstWaypoint.gameObject;
        _currentSpawnCount += 1;

        if (_currentSpawnCount != Waves[_currentWaveIndex].Amount) return;

        _currentWaveIndex += 1;
        _currentSpawnCount = 0;
        CancelInvoke();

        if (_currentWaveIndex < Waves.Length)
        {
            InvokeRepeating("SpawnCurrentWaveEnemy", TimeBetweenWavesSeconds, TimeBetweenSpawnsSeconds);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstWaypoint == null) return;

    }
}
