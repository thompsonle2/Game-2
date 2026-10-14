using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))] // Needed for OnMouseDown click detection
public class CatSprite : MonoBehaviour
{
    [Header("Sprite Options")]
    [SerializeField] private Sprite originalSprite;
    [SerializeField] private Sprite clickedSprite;

    private SpriteRenderer spriteRenderer;
    private bool isClickedState = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Automatically store the initial sprite if not set manually in Inspector
        if (originalSprite == null)
        {
            originalSprite = spriteRenderer.sprite;
        }
    }

    private void OnMouseDown()
    {
        // Toggle state
        isClickedState = !isClickedState;

        // Swap sprite based on current state
        if (isClickedState && clickedSprite != null)
        {
            spriteRenderer.sprite = clickedSprite;
        }
        else if (originalSprite != null)
        {
            spriteRenderer.sprite = originalSprite;
        }
    }
}