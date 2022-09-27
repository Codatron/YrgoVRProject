using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorMovement : MonoBehaviour
{
    public AnimationCurve accelerationCurve;

    private float movementSpeed;

    float horizontalInput;
    float verticalInput;
    float speedPercentage;

    bool isFlying;

    Vector3 movementDirection;
    Vector3 acceleration;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        isFlying = Input.GetKey(KeyCode.Space);

        movementDirection = isFlying ? new Vector3(horizontalInput, 1, verticalInput) : new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        movementSpeed = accelerationCurve.Evaluate(movementDirection.magnitude);

        transform.position += movementDirection * movementSpeed * Time.deltaTime;
    }
}