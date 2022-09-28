using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorMovement : MonoBehaviour
{
    public float movementSpeed;
    float horizontalInput;
    float verticalInput;

    bool isFlying;
    bool isDescending;

    Vector3 movementDirection;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        isFlying = Input.GetKey(KeyCode.Space);
        isDescending = Input.GetKey(KeyCode.LeftShift);

        movementDirection += isFlying ? new Vector3(horizontalInput, 1, verticalInput) : new Vector3(horizontalInput, 0, verticalInput);
        movementDirection += isDescending ? new Vector3(horizontalInput, -1, verticalInput) : new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.position += movementDirection * movementSpeed * Time.deltaTime;
    }
}