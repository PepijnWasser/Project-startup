using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void myEvent(bool value);
    public static event myEvent moving;


    //movement
    [SerializeField]
    private LayerMask platformMask;

    public float moveSpeed;
    public float jumpVelocity = 10f;
    public float midAirControl = 1.0f;

    private Rigidbody2D rigidBody_2d;
    private BoxCollider2D boxCollider_2d;
    private SpriteRenderer renderer;

    private GameObject light;

    public CompositeAbility compositeAbility;

    bool isJumping;
    private float jumpTimeCounter;
    public float jumpTime;
    public float runSpeed;
    public float walkSpeed;

    private void Start()
    {
        rigidBody_2d = transform.gameObject.GetComponent<Rigidbody2D>();
        boxCollider_2d = transform.gameObject.GetComponent<BoxCollider2D>();
        renderer = transform.gameObject.GetComponent<SpriteRenderer>();
        light = GameObject.FindGameObjectWithTag("Light");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody_2d.velocity = Vector2.up * jumpVelocity;
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
           if (jumpTimeCounter>0)
           {
                rigidBody_2d.velocity += Vector2.up * jumpVelocity * Time.deltaTime;
                jumpTimeCounter -= Time.deltaTime;
            }

           else {
               isJumping = false;
           }
           if (Input.GetKeyUp(KeyCode.Space))
           {
               isJumping = false;
           }        
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        } else
        {
            moveSpeed = walkSpeed;
        }
        Movement();
        compositeAbility.HandleAbility(gameObject, light);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider_2d.bounds.center, boxCollider_2d.bounds.size, 0f, Vector2.down, 0.1f, platformMask);
        return raycastHit2D.collider != null;
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            renderer.flipX = true;
            if (IsGrounded())
            {
                rigidBody_2d.velocity = new Vector2(-moveSpeed, rigidBody_2d.velocity.y);
                moving?.Invoke(true);
            }
            else
            {
                rigidBody_2d.velocity += new Vector2(-moveSpeed * midAirControl * Time.deltaTime, 0);
                rigidBody_2d.velocity = new Vector2(Mathf.Clamp(rigidBody_2d.velocity.x, -moveSpeed, moveSpeed), rigidBody_2d.velocity.y);
                moving?.Invoke(false);
            }
        }  
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                renderer.flipX = false;
                if (IsGrounded())
                {
                    rigidBody_2d.velocity = new Vector2(moveSpeed, rigidBody_2d.velocity.y);
                    moving?.Invoke(true);
                }
                else
                {
                    rigidBody_2d.velocity += new Vector2(moveSpeed * midAirControl * Time.deltaTime, 0);
                    rigidBody_2d.velocity = new Vector2(Mathf.Clamp(rigidBody_2d.velocity.x, -moveSpeed, moveSpeed), rigidBody_2d.velocity.y);
                    moving?.Invoke(false);
                }
            }
            else
            {
                if (IsGrounded())
                {
                   rigidBody_2d.velocity = new Vector2(0, rigidBody_2d.velocity.y);
                }
                moving?.Invoke(false);
            }
        }
    }
}
