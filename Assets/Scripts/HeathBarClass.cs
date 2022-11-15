using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarClass : MonoBehaviour
{
    public Slider HealthSlider;
    public Gradient HealthGradient;
    public Image fill;

    public void SetMaxHealth(int maxhp)
    {
        HealthSlider.maxValue = maxhp;
        // Start the game with max hp
        HealthSlider.value = maxhp;

        fill.color = HealthGradient.Evaluate(1f);
    }

    public void SetHealth(int hp)
    {
        HealthSlider.value = hp;
        fill.color = HealthGradient.Evaluate(HealthSlider.normalizedValue);
    }
}
