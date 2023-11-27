using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public int health1 = 100;
    private int MAX_HEALTH = 100;

    public HealthBar healthBar; // Reference to the HealthBar script

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(100);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Heal(10);
        }
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health1 = health1;
        UpdateHealthBar();
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health1 -= amount;

        if (health1 <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health1 + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health1 = MAX_HEALTH;
        }
        else
        {
            this.health1 += amount;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.SetHealth(health1);
        }
    }

    private void Die()
    {
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is Dead!");

            // Load the end game scene
            SceneManager.LoadScene("End Menu"); // Replace with the actual name or index of your end game scene
        }
        else
        {
            Debug.Log("Non-player object is Dead!");
            Destroy(gameObject);
        }
    }
}
