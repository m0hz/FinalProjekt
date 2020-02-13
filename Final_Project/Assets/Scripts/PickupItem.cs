using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    
    public Item item;

    public void OnTriggerEnter(Collider other)
    {
     if (Input.GetKeyDown(interactKey))
        {

        
        Debug.Log("Picking up" + item.name);
         bool wasPickUp =   Inventory.instance.Add(item);
            if (wasPickUp)
        Destroy(gameObject);
        }
    }


   
   
}
