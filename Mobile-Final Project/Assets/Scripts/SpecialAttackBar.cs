using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpecialAttackBar : MonoBehaviour
{
    private int _currentSpecial;

    public Slider specialSlider;
    public int maxSpecial = 5;
    private void Start()
    {
        _currentSpecial = 0;
        UpdateSpecialBar(_currentSpecial);
    }
    public void UpdateSpecialBar(int currentSpecial)
    {
        specialSlider.value = currentSpecial;
    }
}
