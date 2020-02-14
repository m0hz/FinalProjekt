using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;


    public UnityEvent OnHealthChanged;

    private float _startingHealth;

    public float NormalizedValue;

    private void Start()
    {
        _startingHealth = health;

        NormalizedValue = health / _startingHealth;
    }
    public void GainHealth(float heal)
    {
        health += heal;
        NormalizedValue = health / _startingHealth;

        OnHealthChanged.Invoke();


    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        NormalizedValue = health / _startingHealth;

        OnHealthChanged.Invoke();


        if (health <= 0f)
            SceneManager.LoadScene("game_over");
    }
}
