using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool packageAquired = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Stop hitting yourself!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If (the thing we trigger is the package) then print  package picked up
        if (other.tag == "Package")
        {
            Debug.Log("Package Picked up");
            packageAquired = true;
        }

        else if (other.tag == "Customer" && packageAquired == true)
        {
            Debug.Log("Package Delivered");
        }
    }
}
