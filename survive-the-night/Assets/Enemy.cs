using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public GameObject bloodEffect;
    int currentHealth;
    public Animator animator;
    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
    }
    
    public void TakeDamage(int damage, Vector2 position)
    {
        Debug.Log("HealthBar = " + healthBar.value + " Current Health = " + currentHealth);
        Debug.Log("Damage = " + damage);
        currentHealth -= damage;
        healthBar.value = currentHealth;

        Debug.Log("HealtBar = " + healthBar.value + " Current Health = " + currentHealth);
        //Play hurt animation
        var bloodClone = Instantiate(bloodEffect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(bloodClone, bloodClone.GetComponent<ParticleSystem>().main.duration);                        
        
        if (currentHealth <= 0)
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

        animator.SetTrigger("Die");

        Destroy(gameObject, 0.5f);
    }
}
