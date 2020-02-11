using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;
    public float delay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }

    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    }
}
