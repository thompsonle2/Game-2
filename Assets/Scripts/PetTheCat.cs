using UnityEngine;
using UnityEngine.SceneManagement;

public class PetTheCat : MonoBehaviour
{
    [Header("Click Settings")]
    public int requiredClicks = 5;          // Total clicks needed
    public string sceneToLoad;

    private int currentClicks = 0;

    // Detects mouse clicks on objects with a Collider or UI Button events
    private void OnMouseDown()
    {
        currentClicks++;

        Debug.Log($"Clicked {currentClicks}/{requiredClicks} times.");

        if (currentClicks >= requiredClicks)
        {
            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        // Load the configured scene
        SceneManager.LoadScene(sceneToLoad);
    }
}