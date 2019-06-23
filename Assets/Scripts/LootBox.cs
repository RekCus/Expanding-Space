using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    public int health = 300;

    public GameObject moneyPrefab;
    public Transform spawnPoint;
    private SpriteRenderer rend;
    private Sprite b1s,b2s,b3s;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        b1s = Resources.Load<Sprite>("b1"); 
        b2s = Resources.Load<Sprite>("b2");
        b3s = Resources.Load<Sprite>("b3");


        rend.sprite = b1s;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;


        if(health<=300 && health > 200)
        {
            Debug.Log("1");
            rend.sprite = b1s;
        }
        else if (health <= 200 && health > 100)
        {
            Debug.Log("2");
            rend.sprite = b2s;
        }
        else if (health <= 100 && health > 0)
        {
            Debug.Log("3");
            rend.sprite = b3s;
        }


        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Melee")
        {
            TakeDamage(100);
        }
    }
}
