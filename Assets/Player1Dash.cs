using UnityEngine;
using System.Collections;

public class Player1Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool _active = true;
    private Vector2 respawnPoint;

    //Dashing Variables
    private bool canDash = true;
    private bool isDashing;
    private bool hasDashedAir;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    
    // Player movement settings
    [Header("Move and Jump Controls")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    
    public LayerMask groundLayer;

    // Ground check
    private bool isGrounded;

    void Start()
    {
        // Getting components
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        // If not active.. die
        if (!_active) {
            return;
        }
        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            // Handle air dash
            if (!isGrounded && !hasDashedAir)
            {
                canDash = false;
                hasDashedAir = true; // Mark that the air dash has been used
                StartCoroutine(Dash());
            }
            // Handle ground dash
            else if (isGrounded)
            {
                canDash = false;
                StartCoroutine(Dash());
                hasDashedAir = false; // Reset air dash when on the ground
            }
        }

        // Reset air dash when player lands on the ground
        if (isGrounded && hasDashedAir)
        {
            hasDashedAir = false;
        }


        isGrounded = IsGrounded();
        
        // Handle movement
        Move();
        
        // Handle Animation
        ControlAnimation();

        // Handle jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

    }

    void Move()
    {
       
        
        // Get horizontal input (A/D keys or arrow keys)
        float moveInput = Input.GetAxis("Horizontal");
        
        // Apply movement to the Rigidbody2D
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Flip the sprite based on movement direction
        if (moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        } 

        // check if sprite should be set to running
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }
        
        
        
    }

    // control what animation is playing at the given moment
    void ControlAnimation() {
        // check for jump animation
        animator.SetBool("Jumped", !isGrounded);
    }

    void Jump()
    {
        // Apply upward force to the Rigidbody2D
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        // Check if the player is touching the ground using a raycast
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + 0.1f, groundLayer);
        return raycastHit.collider != null;

    }

    // Handle Death
    public void Die() {
        // set active to false and have the player jump out of the level
        _active = false;
        boxCollider.enabled = false;
        Jump();

        // activate the respawn coroutine
        StartCoroutine(Respawn());
    }

    // Handle respawn point
    public void setRespawn(Vector2 respawn) {
        respawnPoint = respawn;
    }

    // Coroutine for respawn
    private IEnumerator Respawn() {
        yield return new WaitForSeconds(1f);
        transform.position = respawnPoint;
        _active = true;
        boxCollider.enabled = true;
        Jump();
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        Vector2 dashDirection = Vector2.zero;
        dashDirection.x = Input.GetAxisRaw("Horizontal");
        dashDirection.y = Input.GetAxisRaw("Vertical");
        dashDirection.Normalize();
        
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(dashDirection * dashingPower, ForceMode2D.Impulse);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        
    }
}
