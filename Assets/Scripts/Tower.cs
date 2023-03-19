using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Damage;
    public float AttackSpeed;
    public int Range;
    private GameObject _targetEnemy;
    private float _timeSinceLastAttack = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Enemy.TagName);

        if (enemies.Length == 0) return;

        _targetEnemy = enemies[0];

        if (!_targetEnemy) return;

        transform.up = _targetEnemy.transform.position - transform.position;
        var targetDistance = Vector2.Distance(transform.position, _targetEnemy.transform.position);
        if (_timeSinceLastAttack > AttackSpeed && targetDistance <= Range)
        {
            Attack();
            _timeSinceLastAttack = 0;
        }

        _timeSinceLastAttack += Time.deltaTime;
    }

    void Attack()
    {
        if (!_targetEnemy) return;
        var enemy = _targetEnemy.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(Damage);
        }
    }
}
