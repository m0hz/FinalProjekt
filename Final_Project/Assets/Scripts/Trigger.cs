using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Door = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlueKey")
        {
            Door.SetActive(false);
        }
    }
    



}
