using UnityEngine;
using TMPro;

public class RandomItem : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI itemDisplayText;

    [Header("Item List")]
    public string[] randomItem = { "get a battery", "find your keys", "fill up your waterbottle" };

    void Start()
    {
        string selectedItem = GetRandomItem();

        // Save text so it can be read in the next scene
        PlayerPrefs.SetString("CurrentObjective", selectedItem);
        PlayerPrefs.Save();

        if (itemDisplayText != null)
        {
            itemDisplayText.text = selectedItem;
        }
        else 
        {
            Debug.Log(selectedItem);
        }
    }

    string GetRandomItem()
    {
        int random = Random.Range(0, randomItem.Length);
        return randomItem[random];
    }
}