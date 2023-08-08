using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Main Game
    //House Healthbar
    public Slider slider;
    public void setMxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health; ;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
