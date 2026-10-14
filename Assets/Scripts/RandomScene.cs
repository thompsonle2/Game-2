using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomScene : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string[] scenesToLoad; // Array of potential scenes

    // Called automatically by UI Button OnClick
    public void LoadTargetScene()
    {
        if (scenesToLoad != null && scenesToLoad.Length > 0)
        {
            // Pick a random scene index
            int randomIndex = Random.Range(0, scenesToLoad.Length);
            string selectedScene = scenesToLoad[randomIndex];

            if (!string.IsNullOrEmpty(selectedScene))
            {
                SceneManager.LoadScene(selectedScene);
            }
            else
            {
                Debug.LogWarning("Selected scene name is empty on " + gameObject.name);
            }
        }
        else
        {
            Debug.LogWarning("No scenes specified in array on " + gameObject.name);
        }
    }

    // Keep OnMouseDown if you also want physical 2D/3D colliders to work
    private void OnMouseDown()
    {
        LoadTargetScene();
    }
}