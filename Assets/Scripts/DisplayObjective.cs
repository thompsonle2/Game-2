using UnityEngine;
using TMPro;

public class DisplayObjective : MonoBehaviour
{
    private TextMeshProUGUI objectiveText;

    void Awake()
    {
        objectiveText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateObjectiveUI();
    }

    public void UpdateObjectiveUI()
    {
        if (objectiveText != null && PlayerPrefs.HasKey("CurrentObjective"))
        {
            objectiveText.text = PlayerPrefs.GetString("CurrentObjective");
        }
    }
}