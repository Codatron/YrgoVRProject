using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Movement
{
    private Rigidbody target;

    public Movement(Rigidbody targetRigidbody)
    {
        target = targetRigidbody;
    }

    public void ChangeAltitude(Vector3 direction, float thrust)
    {
        target.AddForce(direction * thrust, ForceMode.Impulse);
    }

    public void Fly(Vector3 inputDirection, float flySpeed)
    {
        Vector3 movement = Vector3.zero;

        if (inputDirection.magnitude > .15f)
            movement = inputDirection.normalized * inputDirection.magnitude * flySpeed * Time.deltaTime;

        else if (inputDirection.magnitude <= 0.15f && inputDirection.magnitude >= 0.05f)
            movement = Vector3.zero;
        
        target.AddForce(movement, ForceMode.VelocityChange);
    }

    public void FlyWithLoad(Vector3 inputDirection, float flySpeed, float dragIncrease)
    {
        Vector3 movement = Vector3.zero;

        if (inputDirection.magnitude > .15f)
            movement = inputDirection.normalized * inputDirection.magnitude * flySpeed * Time.deltaTime;

        else if (inputDirection.magnitude <= 0.15f && inputDirection.magnitude >= 0.05f)
            movement = Vector3.zero;

        target.drag += dragIncrease;
        target.AddForce(movement, ForceMode.VelocityChange);
    }

    public void Crawl(Vector3 inputDirection, float groundSpeed)
    {
        Vector3 movement = Vector3.zero;

        if (inputDirection.magnitude > .15f)
        {
            movement = inputDirection.normalized * groundSpeed * Time.deltaTime;
            movement.y = 0.0f;
        }
        else if (inputDirection.magnitude <= 0.15f && inputDirection.magnitude >= 0.05f)
        {
            movement = Vector3.zero;
        }

        target.AddForce(movement, ForceMode.VelocityChange);
    }
}
