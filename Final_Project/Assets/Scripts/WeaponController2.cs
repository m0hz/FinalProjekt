using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController2 : MonoBehaviour
{
    public UnityEvent OnFire;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            OnFire.Invoke();
        }
    }
}
