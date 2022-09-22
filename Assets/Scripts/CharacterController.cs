using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 4f;
    public static float jump = 8f;
    public Transform footTransform;
    float distanceCheck = 0.05f;
    float acceleration;
    SpriteRenderer playerSprite;
    Rigidbody2D rb;
    Animator anim;
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>(); 
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update () 
    {
        Move();
        Jump();
    }
    void Move()
    {
        acceleration = 0;

        if (Input.GetKey (KeyCode.A)) 
        {
            //playerSprite.flipX = true;
            acceleration = -speed;
        }
        else if (Input.GetKey (KeyCode.D)) 
        {
            //playerSprite.flipX = false;
            acceleration = speed;
        }
        rb.velocity = new Vector2 (acceleration, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKey (KeyCode.Space) || Input.GetKeyDown (KeyCode.W)) 
        {
            if(IsGrounded())
            {
                rb.velocity = new Vector2 (rb.velocity.x, jump);
            }
        }
    }
    bool IsGrounded() 
    {
        
        RaycastHit2D hit = Physics2D.Raycast(footTransform.position, Vector2.down, distanceCheck);
        Debug.DrawRay(footTransform.position, Vector2.down * distanceCheck, Color.red, 3f);

        if(hit.collider == null)
        {
            return false;
        }
        else if (hit.transform.tag == "Ground") 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
