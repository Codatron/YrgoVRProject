using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorMovement : MonoBehaviour
{
    public float movementSpeed;

    float horizontalInput;
    float verticalInput;

    bool isFlying;

    Vector3 movementDirection;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        isFlying = Input.GetKey(KeyCode.Space);

        movementDirection = isFlying ? new Vector3(horizontalInput, 1, verticalInput) : new Vector3(horizontalInput, 0, verticalInput);

        transform.position += movementDirection * Time.deltaTime * movementSpeed;
    }
}