using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public LayerMask layerMask;

    // Spawning Bullet Prefab
    public GameObject Bullet;

    private int maxHealth = 100;
    private int health;
    public HealthBar healthBar;

    public Camera camera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Move();
        Shoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();

            if (enemyHealth != null)
            {
                enemyHealth.Damage(100); // or any other appropriate value
                Debug.Log("Enemy hit!");
            }
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 cameraForward = new Vector3(camera.transform.forward.x, 0f, camera.transform.forward.z).normalized;

            GameObject bulletInstance = Instantiate(Bullet, transform.position + cameraForward * 2, Quaternion.LookRotation(cameraForward));

            if (bulletInstance != null)
            {
                Destroy(bulletInstance, 2f);
            }
        }
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
        movement.Normalize();

        transform.position += movement * 0.1f;
    }

    private void Die()
    {
        Debug.Log("Player is Dead!");
        SceneManager.LoadScene("End Menu"); // Replace with the actual name or index of your end game scene
    }
}
