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
    [SerializeField] private float groundSpeed;
    [SerializeField] Vector3 controllerOffset;
    public GameObject handSetOffset;

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

        if (IsBeeGrounded())
            newMovement.Crawl(GetFlyingDirection(), groundSpeed);

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
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.15f);
    }

    private float ClampedTriggerValue(float triggerInput, float min, float max)
    {
        return Mathf.Clamp(triggerInput, min, max);
    }

    private void SetControllerLocalPositionToHeadsetOrigin(Vector3 offset)
    {
        // Use mainCamera.transform.localPosition instead of handSetOffset.transform.localPosition to minimize motion sickness
        // In that case, remove the child offset from the camera game object
        rightController.transform.localPosition = mainCamera.transform.localPosition + offset;
        leftController.transform.localPosition = mainCamera.transform.localPosition + offset;
    }

    private Vector3 GetFlyingDirection()
    {
        // use mainCamera.transform.localPosition instead of handSetOffset.transform.localPosition to minimize motion sickness
        return (rightController.transform.localPosition + leftController.transform.localPosition) - mainCamera.transform.localPosition;
    }
}