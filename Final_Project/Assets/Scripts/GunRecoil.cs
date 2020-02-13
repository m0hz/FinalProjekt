using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public Vector3 recoilPosition;

    float time;

    public void Fire()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(recoilPosition, Vector3.zero, time);

        time += Time.deltaTime * 2f;
    }
}
