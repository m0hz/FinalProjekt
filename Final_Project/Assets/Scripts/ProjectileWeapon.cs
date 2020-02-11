using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        Vector3 force = transform.TransformDirection(Vector3.forward) * 2500f;

        projectileRigidbody.AddForce(force);
    }
}
