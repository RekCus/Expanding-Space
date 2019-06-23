﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public int money = 0;
    public int health;
    Animator anim;
    bool jump = false;
    bool isShooting = false;
    public Transform firePoint;
    public GameObject bulletPrefab, slash;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        slash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetTrigger("Jump");
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(shooting());
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(melee(0.5f));
        }

        if (horizontalMove == 0)
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Idle", true);
        }else
        {
            anim.SetBool("Walking", true);
            anim.SetBool("Idle", false);
        }
        
    }
  

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false , jump);
        jump = false;
      
    }

    void fire()
    {
      
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
 
    }

    //void melee()
   //{
    //    slash.SetActive(true);
  //  }

    IEnumerator melee(float time)
    {
        Debug.Log("Start Melee");
        anim.SetTrigger("Attack");
        slash.SetActive(true);
        yield return new WaitForSeconds(time);
        Debug.Log("Stop Melee");
        slash.SetActive(false);
        yield break;
    }

    IEnumerator shooting()
    {
        anim.SetTrigger("Shooting");
        yield return new WaitForSeconds(0.1f);
        fire();
        anim.ResetTrigger("Shooting");
        yield break;

    }



    void pickUpCoin()
    {
        money += 10;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {
            pickUpCoin();
            Debug.Log("PICKUPCOIN");
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5);
        }

        if (collision.gameObject.CompareTag("Spikes"))
        {
            Die();
        }



    }


}
