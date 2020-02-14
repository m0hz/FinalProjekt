using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTrigger : MonoBehaviour
{
    public GameObject Door = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GreenKey")
        {
            Door.SetActive(false);
        }
    }



}
