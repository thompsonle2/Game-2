
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Attach to the Player. Requires: Rigidbody 2D, a Collider 2D, Sprite Renderer.
public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 6f;
    private Animator anim;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    InputAction moveAction;
    InputAction jumpAction;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    public Transform groundCheck; // Assign your ground check child object here in Inspector
    public LayerMask groundLayer;  // Set this to your Ground Layer in Inspector

    void Update()
    {
        // Performs a small circle check at the groundCheck position
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 8f);
        }
    }

    void FixedUpdate()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        float x = move.x;
        float y = move.y;

        rb.linearVelocity = new Vector2(
            x * runSpeed,
            y * runSpeed
        );

        if (x != 0)
            sprite.flipX = x < 0;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}