using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class CatMovement : MonoBehaviour
{
    public float speed = 5f;
    public float chaseDistance = 12f;
    public string sceneToLoad;

    // Ground & Wall Checking
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius = 0.2f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Collider2D catCollider;

    private float moveDirectionX = 1f; // 1 = Right, -1 = Left
    private Transform player;
    private bool isGrounded;

    // Key used to remember if player already touched the cat
    private const string CAT_TOUCHED_KEY = "HasTouchedCat";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        catCollider = GetComponent<Collider2D>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        // If the player already touched the cat before, make the cat pass-through
        if (PlayerPrefs.GetInt(CAT_TOUCHED_KEY, 0) == 1)
        {
            MakePassThrough();
        }
    }

    void Update()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseDistance)
            {
                float directionToPlayer = player.position.x - transform.position.x;
                if (Mathf.Abs(directionToPlayer) > 0.1f)
                {
                    moveDirectionX = Mathf.Sign(directionToPlayer);
                }
            }
        }

        rb.linearVelocity = new Vector2(moveDirectionX * speed, rb.linearVelocity.y);

        if (spriteRenderer != null && moveDirectionX != 0)
        {
            spriteRenderer.flipX = moveDirectionX < 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerFirstContact();
        }
        else
        {
            moveDirectionX *= -1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Safety check in case collider is already a trigger
        if (collision.CompareTag("Player") && PlayerPrefs.GetInt(CAT_TOUCHED_KEY, 0) == 0)
        {
            TriggerFirstContact();
        }
    }

    private void TriggerFirstContact()
    {
        // Save state so the game remembers cat was touched
        PlayerPrefs.SetInt(CAT_TOUCHED_KEY, 1);
        PlayerPrefs.Save();

        // Make pass-through immediately
        MakePassThrough();

        // Load the next scene
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void MakePassThrough()
    {
        if (catCollider != null)
        {
            // Turning on Is Trigger allows player to walk right through without physical blockage
            catCollider.isTrigger = true;
        }
    }

    // Optional helper method to reset cat state (e.g. on new game start)
    public static void ResetCatInteraction()
    {
        PlayerPrefs.DeleteKey(CAT_TOUCHED_KEY);
    }
}