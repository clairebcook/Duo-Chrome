using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private TrailRenderer trail;
    private bool _active = true;

    [Header("Move and Jump Controls")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Dashing")]
    public float dashingVelocity;
    public float dashingTime;
    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash = true;

    [Header("Respawn")]
    public Vector2 respawnPoint;

    [Header("Audio")]
    public AudioManager audioManager;
    
    [Header("Ground")]
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool dashInput;

    [Header("Collider")]
    public Vector2 boxSize;
    public float castDistance;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (!_active) {
            return;
        }

        dashInput = Input.GetKeyDown(KeyCode.LeftShift); 
        isGrounded = IsGrounded();

        if (dashInput && canDash) {
            isDashing = true;
            canDash = false;
            trail.emitting = true;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            StartCoroutine(DashSound());

            if (dashingDir == Vector2.zero) {
                dashingDir = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing());
        }

        if (isDashing) {
            rigidBody.linearVelocity = dashingDir.normalized * dashingVelocity;
            return;
        }

        if (isGrounded) {
            canDash = true;
        }
    

        Move();
        ControlAnimation();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded != false)
        {
            Jump();
            audioManager.playJump();
        }

    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        
        rigidBody.linearVelocity = new Vector2(moveInput * moveSpeed, rigidBody.linearVelocity.y);

        if (moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        } 

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }
    }

    void ControlAnimation() {
        animator.SetBool("Jumped", !isGrounded);
    }

    void Jump()
    {
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer) != false;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    public void Die() {
        _active = false;
        boxCollider.enabled = false;
        StartCoroutine(DeathSound());
        Jump();

        StartCoroutine(Respawn());
    }

    public void setRespawn(Vector2 respawn) {
        respawnPoint = respawn;
    }

    private IEnumerator Respawn() {
        yield return new WaitForSeconds(1f);
        transform.position = respawnPoint;
        _active = true;
        boxCollider.enabled = true;
        Jump();
    }

    private IEnumerator StopDashing() {
        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        isDashing = false;
    }

    private IEnumerator DeathSound() {
        audioManager.playDeath();
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator DashSound() {
        audioManager.playDash();
        yield return new WaitForSeconds(1f);
    }

}
