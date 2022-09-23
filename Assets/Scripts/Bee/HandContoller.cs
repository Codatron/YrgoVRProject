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

    //[Header("State")]
    //[SerializeField] private BeeState beeState;

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
    private BeeStateSwitcher stateSwitcher;

    private void Awake()
    {
        rb = body.GetComponent<Rigidbody>();
        originCollider = body.GetComponent<Collider>();

        vrInput = new VRInput(rightController, leftController);
        newMovement = new Movement(rb);
        stateSwitcher = new BeeStateSwitcher(BeeState.Grounded);
    }

    private void Start()
    {
        mainCamera = Camera.main;
        SetControllerLocalPositionToHeadsetOrigin(controllerOffset);
    }

    private void FixedUpdate()
    {
        stateSwitcher.CurrentBeeState = IsBeeGrounded() ? stateSwitcher.CurrentBeeState = BeeState.Grounded : stateSwitcher.CurrentBeeState = BeeState.Flying;

        if (vrInput.GetRightTrigger() > 0.1f)
            stateSwitcher.CurrentBeeState = BeeState.Lifting;
        else if (vrInput.GetLeftTrigger() > 0.1f && !IsBeeGrounded())
            stateSwitcher.CurrentBeeState = BeeState.Descending;

        switch (stateSwitcher.CurrentBeeState)
        {
            case BeeState.Grounded:
                newMovement.Crawl(GetFlyingDirection(), groundSpeed);
                newMovement.ChangeAltitude(Vector3.up, ClampedTriggerValue(vrInput.GetRightTrigger(), .1f, .35f));
                break;
            case BeeState.Flying:
                newMovement.Fly(GetFlyingDirection(), flySpeed);
                break;
            case BeeState.Hovering:
                break;
            case BeeState.OnFlower:
                newMovement.Crawl(GetFlyingDirection(), groundSpeed);
                newMovement.ChangeAltitude(Vector3.up, ClampedTriggerValue(vrInput.GetRightTrigger(), .1f, .35f));
                break;
            case BeeState.Lifting:
                newMovement.ChangeAltitude(Vector3.up, ClampedTriggerValue(vrInput.GetRightTrigger(), .1f, .35f));
                newMovement.Fly(GetFlyingDirection(), flySpeed);
                break;
            case BeeState.Descending:
                newMovement.ChangeAltitude(Vector3.down, ClampedTriggerValue(vrInput.GetRightTrigger(), .1f, .15f));
                newMovement.Fly(GetFlyingDirection(), flySpeed);
                break;
            case BeeState.CarryingPollen:
                newMovement.Fly(GetFlyingDirection(), flySpeed);
                break;
            default:
                break;
        }


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