using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool packageAquired;
    [SerializeField] float destroyTimer;
    [SerializeField] Color32 PackageAquiredColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Stop hitting yourself!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If (the thing we trigger is the package) then print  package picked up
        if (other.tag == "Package" && !packageAquired)
        {
            Debug.Log("Package Picked up");
            packageAquired = true;
            spriteRenderer.color = PackageAquiredColor;
            Destroy(other.gameObject, destroyTimer);

        }

        else if (other.tag == "Customer" && packageAquired)
        {
            Debug.Log("Package Delivered");
            packageAquired = false;
            spriteRenderer.color = noPackageColor;
            Destroy(other.gameObject, destroyTimer);
        }
    }
}
