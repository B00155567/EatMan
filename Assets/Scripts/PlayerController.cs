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

    public Camera camera;


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
            Vector3 cameraForward = new Vector3(camera.transform.forward.x, 0f, camera.transform.forward.z).normalized;

            GameObject bulletInstance = Instantiate(Bullet, transform.position + cameraForward * 2, Quaternion.LookRotation(cameraForward));


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

        this.transform.position += movement * 0.1f;

        //this.anim.SetFloat("vertical", verticalAxis);
        //this.anim.SetFloat("horizontal", horizontalAxis);
    }
}
