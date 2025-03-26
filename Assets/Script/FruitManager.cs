using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FruitManager : MonoBehaviour
{
    public TMP_Text fruitText;
    public static FruitManager instance; // Singleton instance

    public Dictionary<string, int> fruitCounts = new Dictionary<string, int>(); // Stores different fruit types
  //  public Text fruitText; // UI Text to display the fruit count

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple FruitManager instances detected!"); // Just a warning for debugging
           Destroy(gameObject); // ✅ Prevent multiple instances
          //  return;
        }
    }

    public void AddFruit(string fruitType)
    {
      //  if (string.IsNullOrEmpty(fruitType)) return; // ✅ Prevent errors from null/empty names
        // Check if the fruit type already exists
        if (fruitCounts.ContainsKey(fruitType))
        {
            fruitCounts[fruitType]++; // Increase count
        }
        else
        {
            fruitCounts[fruitType] = 1; // Add new fruit type
        }

        UpdateFruitUI();
    }

    void UpdateFruitUI()
    {
       // if (fruitText == null) // ✅ Prevent NullReferenceException
       // {
           // Debug.LogError("FruitText UI is not assigned in the Inspector!");
           // return;
       // }
        fruitText.text = "Fruits Collected:\n"; // Reset UI text
        foreach (var fruit in fruitCounts)
        {
            fruitText.text += fruit.Key + ": " + fruit.Value + "\n"; // Display each fruit count
        }
    }
}
