using UnityEngine;
 
// Attach to the Main Camera. Drag the Player into the Target slot.
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1f, -10f);  // keep z negative in 2D
    public float smoothing = 5f;                        // higher = snappier
 
    void LateUpdate()   // runs after the player has moved this frame
    {
        Vector3 goal = target.position + offset;
        float t = smoothing * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, goal, t);
    }
}