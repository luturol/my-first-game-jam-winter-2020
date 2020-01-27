using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement; //stores x and y

    // Update is called once per frame
    void Update()
    {
        //Control input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x <  0 && transform.localScale.x > 0)
        {            
            Debug.Log("Runing left " + movement.x);
            transform.localScale = new Vector3(- 1 , transform.localScale.y, transform.localScale.z);
        }
        else if( movement.x > 0)
        {
            Debug.Log("Runing right " + movement.x);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
       
       
    }

    // work same as Update but it control physics
    private void FixedUpdate()
    {
        //Control movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
