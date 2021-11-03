using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 250f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float slowSpeed = 8f;
    [SerializeField] float boostSpeed = 15f;



    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("You are boosting");
            moveSpeed = boostSpeed;
        }
        else if (other.tag == "Customer" && moveSpeed == slowSpeed)
        {
            moveSpeed = 12f;
        }
    }
}
