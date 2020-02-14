using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    public GameObject prefabKey;
    public Transform parent;
    private void OnDestroy()
    {
        GameObject key = Instantiate(prefabKey);
        key.transform.SetParent(parent);

        key.gameObject.SetActive(true);

        key.transform.localRotation = Quaternion.identity;
        key.transform.localPosition = Vector3.zero;

    }
}
