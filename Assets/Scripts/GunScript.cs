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
        GameObject bullet = Instantiate(BulletModel, firePoint.position, 
        firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;
    }
}
