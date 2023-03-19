using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public const string TagName = "Enemy";
    public float Speed = 3f;
    public float Health = 100f;
    /*
    * Armor will reduce the damage an enemy takes by a percentage.
    * 5 armor will reduce damage taken by 5%, and 100 armor by 100%.
    */
    public float Armor = 0f;
    public GameObject TargetObject
    {
        get => _targetObject;
        set => _targetObject = value;
    }
    private GameObject _targetObject;
    private float _health;
    private Vector3 _initialHealthBarScale;

    // Start is called before the first frame update
    void Start()
    {
        _health = Health;
        _initialHealthBarScale = gameObject.transform.GetChild(0).transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetObject == null) return;

        transform.position = Vector2.MoveTowards(transform.position, _targetObject.transform.position, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _targetObject.transform.position) == 0)
        {
            _targetObject = _targetObject.GetComponent<Waypoint>().NextWaypoint;
        }
    }

    void UpdateHealthBar()
    {
        var healthBar = gameObject.transform.GetChild(0);
        var scaleFactor = _health / Health;
        if (_health <= 0)
        {
            scaleFactor = 0;
        }
        var scaledX = _initialHealthBarScale.x * scaleFactor;
        healthBar.transform.localScale = Vector3.Scale(_initialHealthBarScale, new Vector3(scaleFactor, 1, 1));
        var healthBarPosition = healthBar.transform.localPosition;
        healthBar.transform.localPosition = new Vector3(-1 * (1 - scaledX) / 2, healthBarPosition.y, healthBarPosition.z);
    }

    public void TakeDamage(float amount)
    {
        _health -= amount * ((100 - Armor) / 100);
        UpdateHealthBar();
        if (_health <= 0)
        {
            TriggerDeath();
        }
    }

    void TriggerDeath()
    {
        Destroy(gameObject);
    }
}
