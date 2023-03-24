using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded = false;
    private int jumpCount;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }



    private void Start()
    {
        jumpCount = maxJumpCount;
    }

    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");


        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);



        if(Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jumpCount--;
        }
        isJumping = false;




        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if(isGrounded)
        {
            jumpCount = maxJumpCount;
        }
    }



    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = col.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    IEnumerator PowerUpSpeed()
    {
        moveSpeed = 15;
        yield return new WaitForSeconds(5);
        moveSpeed = 10;
    }


    public void SpeedPowerUp()
    {
        StartCoroutine(PowerUpSpeed());
    }
}