using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private TrailRenderer trail;
    private bool _active = true;
    private Vector2 respawnPoint;

    // Player movement settings
    [Header("Move and Jump Controls")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    // Dashing Controls
    [Header("Dashing")]
    public float dashingVelocity;
    public float dashingTime;
    public float dashingCooldown;
    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash = true;

    
    public LayerMask groundLayer;

    // Ground and Dash check
    private bool isGrounded;
    private bool dashInput;

    void Start()
    {
        // Getting components
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        // If not active.. die
        if (!_active) {
            return;
        }

        dashInput = (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)); 
        isGrounded = IsGrounded();

        // Handle Dash
        if (dashInput && canDash) {
            isDashing = true;
            canDash = false;
            trail.emitting = true;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if (dashingDir == Vector2.zero) {
                dashingDir = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing());
        }

        // Handle Dashing
        if (isDashing) {
            rb.linearVelocity = dashingDir.normalized * dashingVelocity;
            return;
        }

        // can we dash?
        if (isGrounded) {
            canDash = true;
        }
    

        // Handle movement
        Move();

        // Handle Animation
        ControlAnimation();

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
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
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
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

    // Coroutine for dashing
    private IEnumerator StopDashing() {
        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        isDashing = false;
    }

}
