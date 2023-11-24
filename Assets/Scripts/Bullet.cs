using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    [SerializeField] private int speed = 10;

    // Update is called once per frame
    void Update()
    {
        // Assuming the bullet moves forward in its local space
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public int GetBulletDamage()
    {
        return damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Check if the collided object has a Health component
            Health enemyHealth = other.GetComponent<Health>();

            if (enemyHealth != null)
            {
                // Deal damage to the enemy
                enemyHealth.Damage(damage);

                // Destroy the bullet
                Destroy(gameObject);
            }
        }
    }
}
