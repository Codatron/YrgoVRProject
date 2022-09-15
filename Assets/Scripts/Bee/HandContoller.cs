using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class HandContoller : MonoBehaviour
{
    public Camera head;
    public GameObject body;
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public Vector3 flightPath;
    public GameObject handOffset;

    [SerializeField] private BeeState beeState;
    [Tooltip("Keep me under 0.5 please.")]
    [SerializeField] private float speed;
    //[SerializeField] private float liftForce;
    //[SerializeField] private float dragForce;
    [SerializeField] private float liftDrag;
    [SerializeField] private float gravitationalDrag;
    [SerializeField] private float rotationSpeed = 45.0f;
    [SerializeField] Vector3 controllerOffset;

    private Rigidbody rb;
    private Collider originCollider;
    private Vector3 direction;
    private Vector3 movement;
    private float distanceToGround;

    private void Awake()
    {
        rb = body.GetComponent<Rigidbody>();
        originCollider = body.GetComponent<Collider>();
    }

    private void Start()
    {
        SetControllerLocalPositionToHeadsetOrigin();
    }

    private void Update()
    {
        if (GetRightTrigger() > 0.1f)
        {
            if (IsBeeGrounded())
                IncreaseAltitude();
            else
                IncreaseAltitude();
        }
        else if (GetLeftTrigger() > 0.1f)
        {
            if (IsBeeGrounded())
                return;
            else
                DecreaseAltitude();
        }
        else if (GetRightTrigger() == 0.0f && GetLeftTrigger() == 0.0f)
        {
            beeState = BeeState.Hovering;
        }

        if (IsBeeGrounded())
        {
            beeState = BeeState.Grounded;
        }
        else
        {
            beeState = BeeState.Flying;
            //Fly();
        }

        //Debug.Log("");
    }

    private bool IsBeeGrounded()
    {
        distanceToGround = originCollider.bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.15f); ;
    }

    private void Fly()
    {
        direction = (rightController.transform.localPosition + leftController.transform.localPosition) - head.transform.localPosition;

        float distanceFromControllerToHeadset = direction.magnitude;

        if (distanceFromControllerToHeadset > 0.15f)
        {
            movement = direction.normalized * speed * Time.deltaTime;
        }

        rb.velocity = movement;
    }

    private void SetControllerLocalPositionToHeadsetOrigin()
    {
        rightController.transform.localPosition = head.transform.localPosition + controllerOffset;
        leftController.transform.localPosition = head.transform.localPosition + controllerOffset;
    }

    private void IncreaseAltitude()
    {
        rb.drag = liftDrag;
        float thrust = Mathf.Clamp(GetRightTrigger(), 0.1f, 0.35f);
        rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
    }

    private void DecreaseAltitude()
    {
        rb.drag = gravitationalDrag;
        float thrust = Mathf.Clamp(GetRightTrigger(), 0.1f, 0.35f);
        rb.AddForce(Vector3.down * thrust, ForceMode.Impulse);
    }

    private Quaternion GetHeadRotation() => head.transform.localRotation;

    private Vector3 GetHeadPosition() => head.transform.localPosition;

    private float GetRightTrigger() => rightController.activateAction.action.ReadValue<float>();

    private float GetLeftTrigger() => leftController.activateAction.action.ReadValue<float>();

    private float GetRightGrip() => rightController.selectAction.action.ReadValue<float>();

    private float GetLeftGrip() => leftController.selectAction.action.ReadValue<float>();
 
    private Vector2 GetRightThumbAxis() => rightController.translateAnchorAction.action.ReadValue<Vector2>();

    private Vector2 GetLeftThumbAxis() => leftController.rotateAnchorAction.action.ReadValue<Vector2>();

    private Quaternion GetRightControllerRotation() => rightController.rotationAction.action.ReadValue<Quaternion>();

    private Quaternion GetLeftControllerRotation() => leftController.rotationAction.action.ReadValue<Quaternion>();

    private Vector3 GetRightControllerPosition() => rightController.positionAction.action.ReadValue<Vector3>();

    private Vector3 GetLeftControllerPosition() => leftController.positionAction.action.ReadValue<Vector3>();
}