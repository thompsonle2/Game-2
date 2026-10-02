using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomItem : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI itemDisplayText;

    [Header("Item List")]

    public string[] randomItem = {"get a battery", "find your keys", "put on jewlery", "fill up your waterbottle"};

    void Start()
    {
        if (itemDisplayText != null)
        {
            itemDisplayText.text = GetRandomItem();
        }
        else
        {
        Debug.Log(GetRandomItem());
        }
        
    }

    string GetRandomItem()
    {
        int random = Random.Range(0, randomItem.Length);
        return randomItem[random];
    }
}
