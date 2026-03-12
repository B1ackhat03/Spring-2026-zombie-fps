using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Where the laser starts (tip of the gun)
    public Transform firePoint;

    // How far the railgun can shoot
    public float laserDistance = 100f;

    // Time between shots (cooldown)
    public float shootCooldown = 3f;

    // The visible laser beam
    public LineRenderer laserLine;

    // Tracks when we are allowed to shoot again
    private float nextShootTime = 0f;

    // Lets the shoot Indicator know if we can shoot
    public bool canShoot
    {
        get {
            return Time.time >= nextShootTime;
        }
    }

    void Update()
    {
        // Left mouse button
        if (Input.GetButtonDown("Fire1"))
        {
            // Check if cooldown is finished
            if (Time.time >= nextShootTime)
            {
                ShootRailGun();

                // Start cooldown timer
                nextShootTime = Time.time + shootCooldown;
            }
        }
    }

    void ShootRailGun()
    {
        // This shoots a ray that detects EVERYTHING in a line
        RaycastHit[] hits = Physics.RaycastAll(firePoint.position, firePoint.forward, laserDistance);

        Vector3 endPoint = firePoint.position + firePoint.forward * laserDistance;

        // Loop through everything the laser hits
        foreach (RaycastHit hit in hits)
        {
            // If we hit a zombie
            if (hit.collider.CompareTag("Zombie"))
            {
                // Destroy the zombie instantly
                Destroy(hit.collider.gameObject);
            }

            // Set beam end point to the farthest hit
            endPoint = hit.point;
        }

        // Draw the laser beam
        StartCoroutine(DrawLaser(firePoint.position, endPoint));
    }

    IEnumerator DrawLaser(Vector3 start, Vector3 end)
    {
        // Turn the laser on
        laserLine.enabled = true;

        // Set the start and end of the beam
        laserLine.SetPosition(0, start);
        laserLine.SetPosition(1, end);

        // Keep the beam visible briefly
        yield return new WaitForSeconds(0.1f);

        // Turn it off
        laserLine.enabled = false;
    }
}
