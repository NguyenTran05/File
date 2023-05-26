using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float JumpHeight;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private BoxCollider2D boxCollider2D;
    
    private float directionX;
    private bool IsJumping;
    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling
    }
    private MovementState movementState;
        void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        ChangDirection();
        UpdateAnimation();
        if (Input.GetButtonDown("Jump"))
        {
            IsJumping= true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            IsJumping = false;
        }
    }
    private void FixedUpdate()
    {
        Moving();
        Jump();

    }
    private void ChangDirection()
    {
        if(directionX > 0)
            // Nhan vat quay sang phai
        {
            spriteRenderer.flipX= false;
        }
        if(directionX < 0)
        // Nhan vat quay sang trai
        {
            spriteRenderer.flipX= true;
        }
    }
    private void Moving()
    {
        rb.velocity = new Vector2(directionX * playerSpeed, rb.velocity.y);
    }
    private void UpdateAnimation()
    {
        if(directionX != 0)
        {   
            //Dang di chuyen
            movementState = MovementState.Running;
        }
        else
        {
            //Dung yen
            movementState = MovementState.Idle;
        }
        if (rb.velocity.y > 0.1f)
        {
            movementState= MovementState.Jumping;
        }

        if(rb.velocity.y < -0.1f)
        {
            movementState= MovementState.Falling;
        }
        animator.SetInteger("State", (int)movementState);
    }
    private void Jump()
    {
        if (IsJumping)
        {
            if (IsGround()) {
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            }

        }
    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center,
                                boxCollider2D.bounds.size,
                                0f,
                                Vector2.down,
                                0.1f,
                                jumpableGround);
    }
}
