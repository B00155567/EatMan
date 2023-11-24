using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
[SerializeField] 
private int damage = 10;

[SerializeField] 
private int health = 100;

[SerializeField] 
private float speed = 1f;

[SerializeField] 
private EnemyData data;

[SerializeField] 
private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer(){
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")){
            if(collider.gameObject.GetComponent<Health>() != null){
                collider.gameObject.GetComponent<Health>().Damage(damage);
                this.getComponent<Health>().Damage(10000);
                        
    }
}
