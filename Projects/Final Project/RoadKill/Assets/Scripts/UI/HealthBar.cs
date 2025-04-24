using UnityEngine;
using UnityEngine.UI; 
public class HealthBar : MonoBehaviour
{
    public PlayerStats playerStats; // Reference to the PlayerStats script
    public Slider healthBar; // Reference to the health bar UI element
    void Start()
    {
        if (playerStats == null || healthBar == null)
        {
            Debug.LogError("PlayerStats or HealthBar is not assigned in the inspector.");
            return;
        }

        healthBar.minValue = 0; //min value for the slider
        healthBar.maxValue = 100; //max value for the slider
        healthBar.value = playerStats.health; //current value for the slider
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerStats.health; // Update the health bar value based on player health
    }
}
