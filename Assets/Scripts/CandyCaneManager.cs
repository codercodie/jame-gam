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
    public float energyDrainRate = 0.5f;
    public float energyRegenerate = 10f;

    [Header("UI Elements")]
    public Slider energySlider;

    void Start()
    {
        currentEnergy = maxEnergy;
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
            currentEnergy = minEnergy; // prevents negative energy
            // oh no I'm too tired to continue... end game here 
        }

        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        // Update the energy bar
        UpdateEnergyBar();
    }

    public void collectCandyCane()
    {
        // Regenerate energy when candy cane selected
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
            collectCandyCane();
            Destroy(collision.gameObject);
            Debug.Log("Collected Candy Cane!");
            Debug.Log("Energy: " + currentEnergy);

        }
    }

    public void UpdateEnergyBar()
    {
        float energyPercentage = currentEnergy / maxEnergy;
        energySlider.value = energyPercentage;
    }
}
