using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Key codes for individual players.
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode jumpKey;

    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius = 0.35f;
    [SerializeField] LayerMask whatIsGround;

    private Rigidbody2D rb;
    private float moveInput = 0;
    private bool facingRight = true;
    private bool isGrounded;

    // Jump variables
    private int jumpCountCurr;
    [SerializeField] int jumpCountBase = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCountCurr = jumpCountBase;
    }

    void Update()
    {
        Move();
        Jump();
    }

    // Move the player rightKey or leftKey based on the player input
    void Move() 
    {
        if (Input.GetKey(leftKey))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (facingRight) {
                Flip();
            }
        }
        if (Input.GetKey(rightKey)) 
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (!facingRight) {
                Flip();
            }
        }
    }

    // Jump or doublejump according to the current number of jumpKey available
    void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && jumpCountCurr > 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCountCurr--;
        }

        // reset the number of jumps available if player is touching ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            jumpCountCurr = jumpCountBase;
        }
    }

    // Flips the player based on the direction of its movement
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
