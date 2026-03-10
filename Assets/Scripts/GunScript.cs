using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public GameObject BulletModel;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left mouse button
        {
            Shoot();
        }
    }


    void Shoot()
    {
        // a -90 degree X rotation to correct the bullet orientation
        Quaternion correctedRotation = firePoint.rotation * Quaternion.Euler(-90f, 0f, 0f);

        GameObject bullet = Instantiate(BulletModel, firePoint.position, correctedRotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;
    }
}
