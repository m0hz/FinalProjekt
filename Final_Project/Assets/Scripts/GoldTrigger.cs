﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTrigger : MonoBehaviour
{
    public GameObject Door = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GoldKey")
        {
            Door.SetActive(false);
        }
    }
}
