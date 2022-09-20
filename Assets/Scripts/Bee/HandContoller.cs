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
    [Header("XR Devices")]
    private Camera mainCamera;
    public GameObject body;
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    [Header("State")]
    [SerializeField] private BeeState beeState;

    [Header("Flight Settings")]
    [Tooltip("Keep me under 0.5 please.")]
    [SerializeField] private float flySpeed;
    [SerializeField] Vector3 controllerOffset;

    private Rigidbody rb;
    private Collider originCollider;
    private float distanceToGround;

    private VRInput vrInput;
    private Movement newMovement;

    private float thrust;

    private void Awake()
    {
        rb = body.GetComponent<Rigidbody>();
        originCollider = body.GetComponent<Collider>();

        vrInput = new VRInput(rightController, leftController);
        newMovement = new Movement(rb);
    }

    private void Start()
    {
        mainCamera = Camera.main;
        SetControllerLocalPositionToHeadsetOrigin(controllerOffset);
    }

    private void FixedUpdate()
    {
        if (!IsBeeGrounded())
            newMovement.Fly(GetFlyingDirection(), flySpeed);

        if (vrInput.GetRightTrigger() > 0.1f)
            newMovement.ChangeAltitude(Vector3.up, ClampedTriggerValue(vrInput.GetRightTrigger(), .1f, .35f));

        else if (vrInput.GetLeftTrigger() > 0.1f && !IsBeeGrounded())
            newMovement.ChangeAltitude(Vector3.down, ClampedTriggerValue(vrInput.GetRightTrigger(), .1f, .15f));

        #region OldCode
        //if (GetRightTrigger() > 0.1f)
        //{
        //    if (IsBeeGrounded())
        //        IncreaseAltitude();
        //    else
        //        IncreaseAltitude();
        //}
        //else if (GetLeftTrigger() > 0.1f)
        //{
        //    if (IsBeeGrounded())
        //        return;
        //    else
        //        DecreaseAltitude();
        //}
        //else if (GetRightTrigger() == 0.0f && GetLeftTrigger() == 0.0f)
        //{
        //    beeState = BeeState.Hovering;
        //}

        //if (IsBeeGrounded())
        //{
        //    beeState = BeeState.Grounded;
        //}
        //else
        //{
        //    beeState = BeeState.Flying;
        //    //Fly();
        //}

        //Debug.Log("");
        #endregion
    }

    private bool IsBeeGrounded()
    {
        distanceToGround = originCollider.bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.15f); ;
    }

    //private void Fly()
    //{
    //    direction = (rightController.transform.localPosition + leftController.transform.localPosition) - mainCamera.transform.localPosition;

    //    float distanceFromControllerToHeadset = direction.magnitude;

    //    if (distanceFromControllerToHeadset > 0.15f)
    //    {
    //        movement = direction.normalized * flySpeed * Time.deltaTime;
    //    }
    //    else if (distanceFromControllerToHeadset <= 0.15f && distanceFromControllerToHeadset >= 0.05f)
    //    {
    //        movement = Vector3.zero;
    //    }

    //    rb.AddForce(movement, ForceMode.VelocityChange);
    //}
    private float ClampedTriggerValue(float triggerInput, float min, float max)
    {
        return Mathf.Clamp(triggerInput, min, max);
    }
    private void SetControllerLocalPositionToHeadsetOrigin(Vector3 offset)
    {
        rightController.transform.localPosition = mainCamera.transform.localPosition + offset;
        leftController.transform.localPosition = mainCamera.transform.localPosition + offset;
    }
    private Vector3 GetFlyingDirection()
    {
        return (rightController.transform.localPosition + leftController.transform.localPosition) - mainCamera.transform.localPosition;
    }

    //private void IncreaseAltitude()
    //{
    //    //rb.drag = liftDrag;
    //    float thrust = Mathf.Clamp(vrInput.GetRightTrigger(), 0.1f, 0.35f);
    //    rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
    //}

    //private void DecreaseAltitude()
    //{
    //    //rb.drag = gravitationalDrag;
    //    float thrust = Mathf.Clamp(vrInput.GetRightTrigger(), 0.1f, 0.15f);
    //    rb.AddForce(Vector3.down * thrust, ForceMode.Impulse);
    //}

    //private float GetRightTrigger() => rightController.activateAction.action.ReadValue<float>();

    //private float GetLeftTrigger() => leftController.activateAction.action.ReadValue<float>();

    //private float GetRightGrip() => rightController.selectAction.action.ReadValue<float>();

    //private float GetLeftGrip() => leftController.selectAction.action.ReadValue<float>();

    //private Vector2 GetRightThumbAxis() => rightController.translateAnchorAction.action.ReadValue<Vector2>();

    //private Vector2 GetLeftThumbAxis() => leftController.rotateAnchorAction.action.ReadValue<Vector2>();

    //private Quaternion GetRightControllerRotation() => rightController.rotationAction.action.ReadValue<Quaternion>();

    //private Quaternion GetLeftControllerRotation() => leftController.rotationAction.action.ReadValue<Quaternion>();

    //private Vector3 GetRightControllerPosition() => rightController.positionAction.action.ReadValue<Vector3>();

    //private Vector3 GetLeftControllerPosition() => leftController.positionAction.action.ReadValue<Vector3>();
}