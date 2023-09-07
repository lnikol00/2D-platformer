using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    private SpriteRenderer sprite;
    Animator anim;

    public LayerMask jumpableGround;
 
    private float dirX = 0f;
    public float moveSpeed = 7f;
    public float jumpForce = 7f;

    private bool doubleJump;
    private int airJumpCount;
    private int airJumpCountMax;

    private enum MovementState { idle, running, jumping, falling, doubleJump }

    public AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        airJumpCountMax = 1;
    }
    // Update is called once per frame
    private void Update()
    {
        if(IsGrounded() && !Input.GetButtonDown("Jump"))
        {
            airJumpCount = 0;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButton("Jump"))
        {
            if(IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                if(Input.GetButtonDown("Jump"))
                {
                    if(airJumpCount < airJumpCountMax)
                    {
                        jumpSoundEffect.Play();
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        airJumpCount++;
                    }
                }
            }
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if(dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;

            if(airJumpCount == 1)
            {
                 state = MovementState.doubleJump;
            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;

            if(airJumpCount == 1)
            {
                 state = MovementState.doubleJump;
            }
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
