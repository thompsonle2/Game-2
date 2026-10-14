using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string sceneToLoad;

    // Called automatically by UI Button OnClick
    public void LoadTargetScene()
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

    // Keep OnMouseDown if you also want physical 2D/3D colliders to work
    private void OnMouseDown()
    {
        LoadTargetScene();
    }
}