using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 8f;

    private Rigidbody2D rb;
    private float horizontalInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 inputVector = context.ReadValue<Vector2>();
            horizontalInput = inputVector.x;
            //debug
            Debug.Log($"Input Received: {horizontalInput}");
        }
       /* else if (context.canceled)
        {
            horizontalInput = 0f;
        }*/
    }

    private void FixedUpdate()
    {
        // Move position safely through the physics solver instead of forcing velocity
        Vector2 targetPosition = rb.position + new Vector2(horizontalInput * moveSpeed * Time.fixedDeltaTime, 0f);
        rb.MovePosition(targetPosition);
    }
}