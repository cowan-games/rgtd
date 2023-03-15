using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 5.0f;
    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject == null) return;

        transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetObject.transform.position) == 0)
        {
            targetObject = targetObject.GetComponent<Waypoint>().NextWaypoint;
        }
    }
}
