using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    public Component target;

    private void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", 1);

        var aiPath = gameObject.GetComponent<AIPath>();
        if (aiPath)
        {
            aiPath.destination = target.transform.position;
        }
            

        if (aiPath.desiredVelocity.x >= 0.01f && (aiPath.desiredVelocity.x > aiPath.desiredVelocity.y)) //moving right
        {
            animator.SetFloat("Horizontal", 1f);
            animator.SetFloat("Vertical", 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f && (aiPath.desiredVelocity.x < aiPath.desiredVelocity.y)) //moving left
        {            
            animator.SetFloat("Horizontal", -1f);
            animator.SetFloat("Vertical", 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(aiPath.desiredVelocity.y >= 0.01f && (aiPath.desiredVelocity.y > (aiPath.desiredVelocity.x * -1)))
        {          
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 1f);
        }
        else
        {
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", -1f);
        }
    }
}
