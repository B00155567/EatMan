// Enemy.cs
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData data;

    private Player player; // Change the type to Player

    void Start()
    {
        // Find the player GameObject by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Respawn");

        if (playerObject != null)
        {
            // Get the Player component from the player GameObject
            player = playerObject.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("Player not found!");
        }

        SetEnemyValues();
    }

    void Update()
    {
        Swarm();

        if(GetComponent<Collider>().CompareTag("Bullet")){
            Die();
        }
    }

    private void SetEnemyValues()
    {
            if (player != null) 
            {
                // Check if player is not null before setting values
                GetComponent<Health>().SetHealth(data.hp, data.hp);
            }
            else
            {
                Debug.LogError("Player reference is null. Cannot set enemy values.");
            }
    }
    private void Swarm()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is null. Cannot swarm.");
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, data.speed * Time.deltaTime);

        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.y = 0; // Ignore vertical difference
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, data.rotationSpeed * Time.deltaTime);

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= data.attackRange)
        {
            // Inflict damage to the player
            player.Damage(data.damage);
            Debug.Log("Player hit!");
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
