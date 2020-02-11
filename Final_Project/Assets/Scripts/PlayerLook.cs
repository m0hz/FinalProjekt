using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxisRaw("Mouse X");

        transform.Rotate(new Vector3(0f, mouse_x, 0f));
    }
}
