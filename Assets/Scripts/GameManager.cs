using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        
        // Quits the compiled build application
        Application.Quit();

        // Stops Play Mode if you are testing inside the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}