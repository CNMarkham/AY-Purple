using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variables for marios horizontal movements
    private Rigidbody2D rb;
    public float movespeed;
    // variables for marios vertical movements
    private RaycastHit2D hit;
    public float jumpforce;
    private bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        // calling the ridgid body
        rb = GetComponent<Rigidbody2D>();

        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        // The horizontal movements for mario using "GetAxis"
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * horizontal * movespeed * Time.deltaTime);
        //calling the Jump method
        Jump();
        FlipDirection();
        ChangeAnimations();

    }

    private void Jump()
    {
        // checking if mario is on the ground using the Circlecast
        hit = Physics2D.CircleCast(rb.position, 0.25f, Vector2.down, 0.375f, LayerMask.GetMask("Default"));
        // checking if space bar is hit (if is the velocity is added to the y-axis)
        if (hit.collider != null && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpforce;
            rb.velocity = velocity;
            jumping = true;

        }

        // checking if jumping is true (continues to add force to the jump)
        if (jumping && Input.GetKey(KeyCode.Space))
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpforce;
            rb.velocity = velocity;
            Invoke("ResetJumping", 0.5f);

        }


    }

    private void ResetJumping()
    {
        jumping = false;
    }

    // flipping the marios direction
    private void FlipDirection()

    {
        foreach(SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.flipX = rb.velocity.x < 0;
        }
    }
    // calling the transitions for the animators
    private void ChangeAnimations()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetFloat("velocityX", rb.velocity.x);
            animator.SetFloat("horizontalInput", Input.GetAxis("Horizontal"));
            animator.SetBool("inAir", hit.collider == null || jumping);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float distance = 0.375f;
        if (GetComponent<PlayerBehavior>().big)
        {
            distance += 1f;

            
        }

        RaycastHit2D hitTop = Physics2D.CircleCast(rb.position, 0.25f, Vector2.up, distance, LayerMask.GetMask("Default"));

        if (hitTop.collider != null)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = 0;
            rb.velocity = velocity;
            jumping = false;
        }

        BlockHit blockhit = hitTop.collider.gameObject.GetComponent<BlockHit>();
        if (blockhit != null)
        {
            blockhit.hit();
        }
    }





}
