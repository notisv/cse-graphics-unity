using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRevolution : MonoBehaviour
{
    // Assign a GameObject in the Inspector to rotate around
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the target at XX degrees/second.
        transform.RotateAround(target.transform.position, Vector3.up, 22.5f * Time.deltaTime);
    }
}
