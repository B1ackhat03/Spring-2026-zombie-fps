using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUIController : MonoBehaviour
{

    public Renderer shootIndicator; // the GunIndicator object
    public GunScript gun; // Reference to  gun script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gun.canShoot)
        {
            shootIndicator.material.color = Color.green; // Ready to shoot
        }

        else
        {
            shootIndicator.material.color = Color.red; // Not ready
        }

    }   

}
