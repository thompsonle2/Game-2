using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float runSpeed = 6f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private InputAction moveAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        // Fetch horizontal move input
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void FixedUpdate()
    {
        if (moveAction == null) return;

        Vector2 move = moveAction.ReadValue<Vector2>();

        // Horizontal movement only (X-axis)
        float x = move.x;

        // Apply horizontal velocity while preserving Y-velocity (for gravity or platform support)
        rb.linearVelocity = new Vector2(x * runSpeed, rb.linearVelocity.y);

        // Flip sprite direction based on movement
        if (x != 0 && sprite != null)
        {
            sprite.flipX = x < 0;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}