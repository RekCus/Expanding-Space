using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int health = 10;
    public GameObject particle;
 
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
      Instantiate(particle, transform.position, Quaternion.identity);
        FindObjectOfType<SoundManager>().Play("EnemyDeath");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Melee")
        {
            TakeDamage(10);
        }
    }
}
