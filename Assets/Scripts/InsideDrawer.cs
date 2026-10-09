using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class SceneChanger : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string sceneToLoad; Drawer

    // Works for standard 2D and 3D object clicks
    private void OnMouseDown()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No scene name specified on " + gameObject.name);
        }
    }
}