using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorMovement : MonoBehaviour
{
    public AnimationCurve accelerationCurve;

    public float movementSpeed;
    private float maxSpeed = 100;
    private float currentSpeed;

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

        speedPercentage = transform.position.magnitude / maxSpeed;

        transform.position += movementDirection * accelerationCurve.Evaluate(speedPercentage) * movementSpeed * Time.deltaTime;
    }
}