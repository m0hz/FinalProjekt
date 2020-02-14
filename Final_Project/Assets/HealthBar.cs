using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();

        health.OnHealthChanged.AddListener(UpdateHealthBar);
    }

    void UpdateHealthBar()
    {
        image.fillAmount = health.NormalizedValue;
    }
}
