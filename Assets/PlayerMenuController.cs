using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMenuController : MonoBehaviour
{
    private Camera mainCamera;
    [Header("XR Devices")]
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    [SerializeField] Vector3 controllerOffset;
    public GameObject handSetOffset;

    private VRInput vrInput;

    private void Awake()
    {
        mainCamera = Camera.main;
        vrInput = new VRInput(rightController, leftController);
    }

    private void Start()
    {
        SetControllerLocalPositionToHeadsetOrigin(controllerOffset);
    }

    private void SetControllerLocalPositionToHeadsetOrigin(Vector3 offset)
    {
        rightController.transform.localPosition = mainCamera.transform.localPosition + offset;
        leftController.transform.localPosition = mainCamera.transform.localPosition + offset;
    }
}
