using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private float moveInput;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private string namePlayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        namePlayer = gameObject.transform.name;

        switch (namePlayer)
        {
            case "player_1":
                if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;
                }
                else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
                break;

            case "player_2":
                if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
                break;

            default:
                break;
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "attack")
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
