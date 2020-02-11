using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float range = 100f;
    public float damage = 1f;
    public Camera fpsCam;
    public AudioSource Handgun;

    private void Start()
    {


    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }

    void Shoot()
    {

        Handgun.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
