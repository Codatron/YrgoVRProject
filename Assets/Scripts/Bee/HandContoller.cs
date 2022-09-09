using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public enum BeeState
{
    Stationary,
    Flying
}

public class HandContoller : MonoBehaviour
{
    public GameObject body;
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    Vector3 rightControllerPosition;
    Quaternion rightControllerRotation;
    Vector3 targetForward;

    [Tooltip("Keep me under 0.5 please.")]
    [SerializeField] private float speed;

    private void Update()
    {
        // Controller position
        // rightControllerPosition = rightController.positionAction.action.ReadValue<Vector3>();

        body.transform.localRotation = GetControllerRotation();
        targetForward = GetControllerRotation() * body.transform.forward;
        body.transform.localPosition += targetForward * speed * Time.deltaTime;
    }

    private Quaternion GetControllerRotation()
    {
        return rightController.rotationAction.action.ReadValue<Quaternion>();
    }
    private Vector3 GetControllerPosition()
    {
        return rightController.positionAction.action.ReadValue<Vector3>();
    }
}