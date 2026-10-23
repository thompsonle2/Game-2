using UnityEngine;

public class SceneObjectiveSetter : MonoBehaviour
{
    [Header("Objective Settings")]
    [TextArea(2, 5)]
    [SerializeField] private string newObjective = "Reply To Text Messages";

    [SerializeField] private bool overwriteExisting = true;

    void Start()
    {
        SetObjective();
    }

    public void SetObjective()
    {
        // Set objective if allowed to overwrite, or if no objective has been saved yet
        if (overwriteExisting || !PlayerPrefs.HasKey("CurrentObjective"))
        {
            PlayerPrefs.SetString("CurrentObjective", newObjective);
            PlayerPrefs.Save();
            Debug.Log($"Objective set to: \"{newObjective}\"");
        }
    }
}