using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandyCaneManager : MonoBehaviour
{
    [Header("Player")]
    public Movement movement;

    [Header("Energy Values")]
    public float currentEnergy;
    public float maxEnergy = 100f;
    public float minEnergy = 0f;
    public float energyDrainRate = 3f;
    public float energyRegenerate = 5f;
    public GameManager gameManager;

    [Header("UI Elements")]
    public Slider energySlider;

    void Start()
    {
        currentEnergy = maxEnergy;

        // Set slider min and max values
        energySlider.minValue = 0;
        energySlider.maxValue = 1;

        Debug.Log("Energy: " + currentEnergy);
    }

    void Update()
    {
        if (movement.IsMoving())
        {
            currentEnergy -= energyDrainRate * Time.deltaTime; // if moving, use energy
        }

        if (currentEnergy < minEnergy)
        {
            currentEnergy = minEnergy;
        }
        if (currentEnergy == minEnergy) 
        {
            gameManager.GameOver();
        }

        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        // Update the energy bar
        UpdateEnergyBar();
    }

    public void CollectCandyCane()
    {
        // Regenerate energy when candy cane is collected
        currentEnergy += energyRegenerate;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("CandyCane"))
        {
            CollectCandyCane();
            Destroy(collision.gameObject);
            Debug.Log("Collected Candy Cane!");
            Debug.Log("Energy: " + currentEnergy);
        }
    }

    public void UpdateEnergyBar()
    {
        // Calculate the inverted energy percentage
        float energyPercentage = currentEnergy / maxEnergy;
        energySlider.value = 1 - energyPercentage; // Invert the value
    }
}
