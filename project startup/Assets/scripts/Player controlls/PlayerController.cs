using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    [SerializeField]
    private LayerMask platformMask;

    public float moveSpeed;
    public float jumpVelocity = 10f;
    public float midAirControl = 1.0f;

    bool croached = false;
    public float croachmultiplier = 0.5f;

    private Rigidbody2D rigidBody_2d;
    private BoxCollider2D boxCollider_2d;
    private SpriteRenderer renderer;

    private GameObject light;

    public CompositeAbility compositeAbility;

    public float sizeYCroached;
    public float sizeYstanding;


    private void Start()
    {
        rigidBody_2d = transform.gameObject.GetComponent<Rigidbody2D>();
        boxCollider_2d = transform.gameObject.GetComponent<BoxCollider2D>();
        renderer = transform.gameObject.GetComponent<SpriteRenderer>();
        light = GameObject.FindGameObjectWithTag("Light");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody_2d.velocity = Vector2.up * jumpVelocity;
            croached = false;
        }
        Movement();
        croach();
        ChangeHitbox();
        compositeAbility.HandleAbility(gameObject, light);
        Debug.Log(croached);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider_2d.bounds.center, boxCollider_2d.bounds.size, 0f, Vector2.down, 0.1f, platformMask);
        return raycastHit2D.collider != null;
    }

    void ChangeHitbox()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if(croached)
        {
            collider.size = new Vector2(collider.size.x, sizeYCroached);
            collider.offset = new Vector2(0, (sizeYstanding - sizeYCroached) / 2);
        }
        else
        {
            collider.size = new Vector2(collider.size.x, sizeYstanding);
            collider.offset = new Vector2(0, 0);
        }
    }

    void croach()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (croached)
            {
                croached = false;
            }
            else
            {
                croached = true;
            }
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            renderer.flipX = true;
            if (IsGrounded())
            {
                if (croached)
                {
                    rigidBody_2d.velocity = new Vector2(-moveSpeed * croachmultiplier, rigidBody_2d.velocity.y);
                }
                else
                {
                    rigidBody_2d.velocity = new Vector2(-moveSpeed, rigidBody_2d.velocity.y);
                }

            }
            else
            {
                rigidBody_2d.velocity += new Vector2(-moveSpeed * midAirControl * Time.deltaTime, 0);
                rigidBody_2d.velocity = new Vector2(Mathf.Clamp(rigidBody_2d.velocity.x, -moveSpeed, moveSpeed), rigidBody_2d.velocity.y);
            }
        }  
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                renderer.flipX = false;
                if (IsGrounded())
                {
                    if (croached)
                    {
                        rigidBody_2d.velocity = new Vector2(moveSpeed * croachmultiplier, rigidBody_2d.velocity.y);
                    }
                    else
                    {
                        rigidBody_2d.velocity = new Vector2(moveSpeed, rigidBody_2d.velocity.y);
                    }

                }
                else
                {
                    rigidBody_2d.velocity += new Vector2(moveSpeed * midAirControl * Time.deltaTime, 0);
                    rigidBody_2d.velocity = new Vector2(Mathf.Clamp(rigidBody_2d.velocity.x, -moveSpeed, moveSpeed), rigidBody_2d.velocity.y);
                }
            }
            else
            {
                if (IsGrounded())
                {
                    rigidBody_2d.velocity = new Vector2(0, rigidBody_2d.velocity.y);
                }

            }
        }
    }
}
