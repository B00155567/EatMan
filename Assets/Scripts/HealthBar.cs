using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider hSlider;
    public Gradient hGradient;
    public Image fill;

    public void SetMaxHealth(int health) {

        hSlider.maxValue = health;
        hSlider.value = health;

        fill.color = hGradient.Evaluate(1f);
    }

    public void SetHealth(int health) {

        hSlider.value = health;

        fill.color = hGradient.Evaluate(hSlider.normalizedValue);
    }
}
