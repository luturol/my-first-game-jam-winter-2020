using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }        
    }

    void Attack()
    {
        //Playe an attack animation
        animator.SetTrigger("Attack");
        Debug.Log("Set animation");
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemyCollided in hitEnemies)
        {
            Debug.Log("We hit " + enemyCollided.name);
            var enemy = enemyCollided.GetComponent<Enemy>();
            enemy.TakeDamage(attackDamage, new Vector2(transform.position.x, transform.position.y));
            pushEnemyAway(enemy);
        }
    }

    private void pushEnemyAway(Enemy enemy)
    {        

        var magnitude = 2500;
        var force = transform.position - enemy.transform.position;
        force.Normalize();

        Debug.Log("Force " + force);

        enemy.GetComponent<Rigidbody2D>().AddForce(force * magnitude, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colidded ");
        if(collision.name != this.name)
        {
            Debug.Log("Hited object " + collision.name);
            Debug.Log("player position " + transform.position.ToString());
            
            Debug.Log("" + collision.gameObject.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
