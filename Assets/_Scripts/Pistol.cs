using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 4f;
    public float impactForce = 100f;
    public LayerMask impactMask;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bloodEffect;

    private float nextTimeToFire = 0f;

    void Update()
    {
     if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject impactEnemy = Instantiate(bloodEffect, hit.point,
                    Quaternion.LookRotation(hit.normal));
                Destroy(impactEnemy, 2f);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (hit.transform.gameObject.layer == impactMask)
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point,
                    Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
                Debug.Log("Ok");
            }
        }
    }
}
