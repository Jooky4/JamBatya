using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;
    [SerializeField]
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    [SerializeField]

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight && moveInput < 0)
        {
            Flip(); 
        }

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log("Jump");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }





}
