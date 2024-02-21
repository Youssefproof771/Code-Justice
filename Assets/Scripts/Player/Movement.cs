using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float acceleration;
    [SerializeField] LayerMask ground;

    Rigidbody2D rb;
    BoxCollider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        MovementHandler();
        JumpHandler();
    }
    private void MovementHandler()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float targetspeed = horizontal * speed;
        float currentspeed = rb.velocity.x;
        if (currentspeed < targetspeed)
        {
            currentspeed += acceleration * Time.deltaTime;
            if (currentspeed > targetspeed)
            {
                currentspeed = targetspeed;
            }
        }
        else if (currentspeed > targetspeed)
        {
            currentspeed -= acceleration * Time.deltaTime;
            if (currentspeed < targetspeed)
            {
                currentspeed = targetspeed;
            }
        }
        rb.velocity = new Vector2(currentspeed, rb.velocity.y);
    }
    private void JumpHandler()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.2f, ground);
    }
}