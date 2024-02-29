using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.Space;
    public GameObject Projectile;
    public float shootForce;
    private Vector3 scaleChange;

    // Get random scale number in range [1.0,5.0]
    public float getRandomNumberInRange()
    {
        float max = 5.0f;
        float min = 1.0f;
         
        System.Random rnd = new System.Random();
        double value = rnd.NextDouble() * (max - min) + min;
        return (float)value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            // Create Projectile
            GameObject shot = GameObject.Instantiate(Projectile, transform.position, transform.rotation);

            // Scale Projectile
            float radius = getRandomNumberInRange();
            scaleChange = new Vector3(radius, radius, radius);
            shot.transform.localScale = scaleChange;
            
            // Move Projectile
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            
            // Destroy the projectile after 3 seconds
            Destroy(shot, 3f);
        }
    }
}