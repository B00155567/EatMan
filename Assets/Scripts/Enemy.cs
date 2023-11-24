using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Swarm()
{
    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
}


    private void OnTriggerEnter(Collider collider)
{
    if (collider.CompareTag("Player"))
    {
        Health playerHealth = collider.GetComponent<Health>();

        if (playerHealth != null)
        {
            playerHealth.Damage(damage);
        }

        StartCoroutine(DestroyAfterDelay(1.0f)); // Adjust the delay as needed
    }
}

private IEnumerator DestroyAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);

    // Destroy the enemy after the specified delay
    Destroy(gameObject);
}

}
