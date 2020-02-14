using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    public PlayerHealth health;

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
