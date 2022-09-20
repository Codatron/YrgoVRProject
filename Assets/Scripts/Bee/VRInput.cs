using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRInput
{
    private ActionBasedController rightController;
    private ActionBasedController leftController;

    public VRInput(ActionBasedController rightController, ActionBasedController leftController)
    {
        this.rightController = rightController;
        this.leftController = leftController;

        
    }

    

    //  RIGHT CONTROLLER
    public float GetRightTrigger() => rightController.activateAction.action.ReadValue<float>();
    public float GetRightGrip() => rightController.selectAction.action.ReadValue<float>();
    public Vector2 GetRightThumbAxis() => rightController.translateAnchorAction.action.ReadValue<Vector2>();
    public Quaternion GetRightControllerRotation() => rightController.rotationAction.action.ReadValue<Quaternion>();
    public Vector3 GetRightControllerPosition() => rightController.positionAction.action.ReadValue<Vector3>();

    //  LEFT CONTROLLER
    public float GetLeftTrigger() => leftController.activateAction.action.ReadValue<float>();
    public float GetLeftGrip() => leftController.selectAction.action.ReadValue<float>();
    public Vector2 GetLeftThumbAxis() => leftController.rotateAnchorAction.action.ReadValue<Vector2>();
    public Quaternion GetLeftControllerRotation() => leftController.rotationAction.action.ReadValue<Quaternion>();
    public Vector3 GetLeftControllerPosition() => leftController.positionAction.action.ReadValue<Vector3>();
}