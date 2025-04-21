using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartManager : MonoBehaviour
{
    public List<Image> hearts;   // Assign heart images in Inspector
    public int maxLives = 3;
    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
        UpdateHearts();
    }

    public void TakeDamage()
    {
        if (currentLives <= 0) return;

        currentLives--;
        UpdateHearts();

        if (currentLives <= 0)
        {
            Debug.Log("Player is Dead!");
            // You can call Game Over here
        }
    }

    public void ResetHearts()
    {
        currentLives = maxLives;
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }
}
