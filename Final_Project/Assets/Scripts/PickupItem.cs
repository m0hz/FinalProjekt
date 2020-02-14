using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
   public GameObject MainShpere;
    private PlayerMove m_player;

    public Item item;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected " + gameObject.name);

        if (other.gameObject.tag == "Player")
        {

            //if (Input.GetKeyDown(interactKey))
           // {


                Debug.Log("Picking up" + item.name);
                bool wasPickUp = Inventory.instance.Add(item);
                if (wasPickUp)
                    Destroy(MainShpere);
           // }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision unDetected");
    }





}
