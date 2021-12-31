using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    float steerSpeed = 300f;
    float moveSpeed = 20f;
    float slowSpeed = 15f;
    float boostSpeed = 30f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Boost") {
            moveSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "WorldObject") {
            moveSpeed = slowSpeed;
        }
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
