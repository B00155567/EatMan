using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;

    //Spawning Bullet Prefab
    public GameObject Bullet;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        Grounded();
        Jump();
        Move();
        Shoot();
        Damage();
    }

    public void Damage() {
        if (Input.GetKeyDown(KeyCode.K)) {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(1)){
            GameObject bulletInstance = Instantiate(Bullet, transform.position + new Vector3(0, 3, 0), Bullet.transform.rotation);

            if (bulletInstance != null){
                Destroy(bulletInstance, 2f);
            }
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
    }

    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
        {
            this.grounded = true;
        }
        else
        {
            this.grounded = false;
        }
        //this.anim.SetBool("jump", this.grounded);
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.04f;

        //this.anim.SetFloat("vertical", verticalAxis);
        //this.anim.SetFloat("horizontal", horizontalAxis);
    }
}
