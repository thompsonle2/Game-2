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
        // Refresh corner objective text when returning to MainGame scene
        if (PlayerPrefs.HasKey("CurrentObjective"))
        {
            objectiveText.text = PlayerPrefs.GetString("CurrentObjective");
        }
    }
}