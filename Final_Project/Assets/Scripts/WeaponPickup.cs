using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponPickup : MonoBehaviour
{
    public UnityEvent OnWeaponPickup; 

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("string OnTrigger Enter");

        OnWeaponPickup.Invoke();
    }


}
        
    

