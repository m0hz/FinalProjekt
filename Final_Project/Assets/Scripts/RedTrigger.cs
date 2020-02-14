using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrigger : MonoBehaviour
{
    public GameObject Door = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedKey")
        {
            Door.SetActive(false);
        }
    }

}
