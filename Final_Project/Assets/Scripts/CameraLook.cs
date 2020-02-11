using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        float mouse_y = Input.GetAxisRaw("Mouse Y");

        rotation += new Vector3(mouse_y, 0f, 0f);

        transform.localRotation = Quaternion.Euler(rotation * -1f);
    }
}
