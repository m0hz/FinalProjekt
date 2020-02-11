using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public UnityEvent OnFire;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnFire.Invoke();
        }
    }
}

