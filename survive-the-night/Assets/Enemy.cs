using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public GameObject bloodEffect;
    int currentHealth;
    

    void Start()
    {
        this.currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        Instantiate(bloodEffect, gameObject.transform.position, gameObject.transform.rotation);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");

        //Play death animation
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}
