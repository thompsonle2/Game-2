using UnityEngine;

public class KillBug : MonoBehaviour
{
    // Triggers when using "Is Trigger" colliders (e.g. collectibles, checkpoints)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Triggers when using solid physics colliders (e.g. breakable boxes, obstacles)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}