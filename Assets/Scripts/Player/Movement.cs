using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float acceleration;
    [SerializeField] LayerMask ground;
    [SerializeField] NPCConversation conversation;

    Rigidbody2D rb;
    BoxCollider2D col;
    Animator anim;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ConversationManager.Instance.StartConversation(conversation);
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

        anim.SetInteger("velocityY",(int)rb.velocity.y);

        if (currentspeed != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (currentspeed > 0)
        {
            //spriteRenderer.flipX = false;
            transform.localScale = new Vector3(1,1,1); 
        }
        else if (currentspeed < 0) 
        {
           // spriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1,1,1); 
        }

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