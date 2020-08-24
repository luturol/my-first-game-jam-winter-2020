using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int life;
    public Transform PortalActivationArea;
    public float PortalActivationRange;
    public LayerMask enemyLayers;
    void Start()
    {
        if (life == 0)
            life = 10;
    }

    void Update()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PortalActivationArea.position, PortalActivationRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemyCollided in hitEnemies)
        {            
            var enemy = enemyCollided.GetComponent<Enemy>();
            enemy.TakeDamage(enemy.maxHealth, new Vector2(transform.position.x, transform.position.y));            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Treant" + other.gameObject.name);
    }

    private void OnDrawGizmosSelected()
    {
        if (PortalActivationArea == null)
            return;

        Gizmos.DrawWireSphere(PortalActivationArea.position, PortalActivationRange);
    }
}
