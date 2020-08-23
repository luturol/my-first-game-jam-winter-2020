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
    private Slider sliderHealth;

    void Start()
    {
        currentHealth = maxHealth;            
    }
    
    public void SetHealthBar(Slider healthBar)
    {
        currentHealth = maxHealth;
        sliderHealth = healthBar;                
        sliderHealth.value = currentHealth;
        sliderHealth.maxValue = maxHealth;
    }

    public void TakeDamage(int damage, Vector2 position)
    {
        currentHealth -= damage;
        sliderHealth.value = currentHealth;
        
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
        //Play death animation
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;        

        animator.SetTrigger("Die");
        
        Destroy(gameObject, 0.5f);
    }
}
