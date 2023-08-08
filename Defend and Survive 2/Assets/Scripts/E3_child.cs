using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_child : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    private Transform target;
    Vector3 MoveDir;

    //health
    public float health;

    //Damage of attacks
    public float damage = 30;
    //bool attackActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("House").transform;
        //coin = GameObject.Find("CoinCounter").GetComponent<Coins>();
    }

    void Update()
    {
        Vector3 position = (target.position - transform.position).normalized;
        MoveDir = position;
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector3(MoveDir.x, MoveDir.y, MoveDir.z) * speed;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
        //coin.updateCoins(coinDropped);
        Debug.Log("destroyed");

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "House")
        {
            //Debug.Log("Damage");
            //collision.gameObject.GetComponent<playerHealth>().TakeDamage(attackDamage);
            collision.gameObject.GetComponent<houseScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
