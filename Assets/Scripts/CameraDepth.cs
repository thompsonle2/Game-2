using UnityEngine;

public class CameraDepth : MonoBehaviour
{
    [Header("Target Tracking")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float smoothTime = 0.2f;

    [Header("Background Layers")]
    [Tooltip("Distant layer (e.g., Sky/Mountains). Moves slowest.")]
    [SerializeField] private Transform farBackground;
    [SerializeField, Range(0f, 1f)] private float farParallaxEffect = 0.8f;

    [Tooltip("Middle layer (e.g., Buildings/Trees). Moves at medium speed.")]
    [SerializeField] private Transform midBackground;
    [SerializeField, Range(0f, 1f)] private float midParallaxEffect = 0.5f;

    [Tooltip("Close layer or static background frame.")]
    [SerializeField] private Transform nearBackground;
    [SerializeField, Range(0f, 1f)] private float nearParallaxEffect = 0.2f;

    private Vector3 lastCameraPosition;
    private Vector3 currentVelocity;

    private void Start()
    {
        lastCameraPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (playerTransform == null) return;

        // Smoothly follow the player horizontally
        Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

        // Calculate horizontal delta movement of camera
        Vector3 deltaMovement = transform.position - lastCameraPosition;

        // Apply parallax offsets to background layers
        if (farBackground != null)
            farBackground.position += new Vector3(deltaMovement.x * farParallaxEffect, 0f, 0f);

        if (midBackground != null)
            midBackground.position += new Vector3(deltaMovement.x * midParallaxEffect, 0f, 0f);

        if (nearBackground != null)
            nearBackground.position += new Vector3(deltaMovement.x * nearParallaxEffect, 0f, 0f);

        lastCameraPosition = transform.position;
    }
}