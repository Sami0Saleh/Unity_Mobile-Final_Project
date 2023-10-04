using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private int _currentHealth;

    public Slider healthSlider;
    public int maxHealth = 100; 
    private void Start()
    {
        _currentHealth = maxHealth;
        UpdateHealthBar(_currentHealth);
    }
    public void UpdateHealthBar(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}
