using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    public Waypoint FirstWaypoint;
    public Enemy EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (FirstWaypoint == null || EnemyPrefab == null) return;

        Enemy instantiatedEnemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        instantiatedEnemy.targetObject = FirstWaypoint.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstWaypoint == null || EnemyPrefab == null) return;



    }
}
