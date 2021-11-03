using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool packageAquired = false;
    [SerializeField] float destroyTimer;

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
            Destroy(other.gameObject, destroyTimer);
        }

        else if (other.tag == "Customer" && packageAquired == true)
        {
            Debug.Log("Package Delivered");
            packageAquired = false;
        }
    }
}
