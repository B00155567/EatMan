using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData data;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    void Update()
    {
        Swarm();
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        // Set other enemy attributes using data
        // Example:
        // GetComponent<SomeComponent>().SetSomething(data.something);
    }

    private void Swarm()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, data.speed * Time.deltaTime);

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= data.attackRange)
        {
            Health playerHealth = player.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.Damage(data.damage);
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
