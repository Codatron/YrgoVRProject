using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// What this script does:
/// Detects the connection status of our XR devices.
/// Returns the name and characteristics of the connected devices to the console.
/// Blueprint for accessing controllers and listening for their inputs.
/// </summary>

public class InputReader : MonoBehaviour
{
    public GameObject XROrigin;
    
    [SerializeField] private List<InputDevice> inputDevices = new List<InputDevice>();
    private float timer;
    private float timeToNextDeviceConnectionCheck = 30.0f;
    private InputDevice targetDevice;

    private void OnEnable()
    {
        InputDevices.deviceConnected += OnDeviceConnected;
        InputDevices.deviceDisconnected += OnDeviceDisconnected;    
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= OnDeviceConnected;
        InputDevices.deviceDisconnected -= OnDeviceDisconnected;
    }

    void Start()
    {
        InitializeInputReader();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeToNextDeviceConnectionCheck)
        {
            if (inputDevices.Count < 2)
            {
                Debug.Log("Reconnecting devices");
                InitializeInputReader();
            }

            timer = 0.0f;
        }
    }

    private void InitializeInputReader()
    {
        InputDevices.GetDevices(inputDevices);
        //InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        //InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, inputDevices);

        foreach (var item in inputDevices)
        {
            Debug.Log(item.name + " " + item.characteristics);
        }

        //if (inputDevices.Count > 0)
        //{
        //    targetDevice = inputDevices[0];
        //}
    }

    private void OnDeviceConnected(InputDevice device)
    {
        Debug.Log("Connection: " + device.name);
    }

    private void OnDeviceDisconnected(InputDevice device)
    {
        Debug.Log("Disconnected: " + device.name);
    }
}

        //targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        //if (primaryButtonValue)
        //{
        //    Debug.Log("Primary Button Pressed");
        //}

        //targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        //if (triggerValue > 0.1f)
        //{
        //    Debug.Log("Trigger Button Pressed");
        //}

        //targetDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotationValue);
        //if (rotationValue.x > 0.1f)
        //{
        //    float someRotation = rotationValue.x;
        //    Vector3 forwardVector = someRotation * Vector3.forward;

        //    float radianAngle = Mathf.Atan2(forwardVector.z, forwardVector.x);
        //    float degreeAngle = radianAngle * Mathf.Rad2Deg;

        //    //float pitch = rotationValue.eulerAngles.x / 360.0f;
        //    //float yaw = rotationValue.eulerAngles.y / 360.0f;
        //    //float roll = rotationValue.eulerAngles.z / 360.0f;

        //    XROrigin.transform.rotation = new Quaternion(degreeAngle, rotationValue.y, rotationValue.z, 0.0f);
        //    Debug.Log(degreeAngle);

        //}

        //targetDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotationValue);
        //if (rotationValue.eulerAngles.x > 0.1f)
        //{
        //    float pitch = rotationValue.eulerAngles.z / 360.0f;
        //    float yaw = rotationValue.eulerAngles.y;
        //    float roll = rotationValue.eulerAngles.x / 360.0f;


        //    XROrigin.transform.localRotation = new Quaternion(XROrigin.transform.localRotation.x, yaw, XROrigin.transform.localRotation.z, XROrigin.transform.localRotation.w);
        //    Debug.Log("Rotation values: Pitch: " + pitch + "  Yaw: " + yaw + "  Roll: " + roll);
        //}

        //targetDevice.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out Vector3 rotationValue);
        //if (rotationValue.x >= 0.1f || rotationValue.y > 0.1f || rotationValue.z > 0.1f)
        //{
        //    //float pitchTurnRate = rotationValue.x;
        //    //float yawTurnRate = rotationValue.y;
        //    //float rollTurnRate = rotationValue.z;

        //    float pitch = rotationValue.x;
        //    float yaw = rotationValue.y;
        //    float roll = rotationValue.z;


        //    Quaternion newRotation = Quaternion.Euler(pitch, yaw, roll);
        //    XROrigin.transform.rotation = newRotation;
        //    Debug.Log("Rotation values: Pitch: " + pitch + "  Yaw: " + yaw + "  Roll: " + roll);
        //}

        //targetDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocityValue);
        //if (velocityValue.x > 0.1f)
        //{
        //    Debug.Log("Right");
        //}
        //else if (velocityValue.x <= 0.1f)
        //{
        //    Debug.Log("Left");
        //}

        //targetDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 positionValue);
        //if (positionValue.x > 0.0f)
        //{
        //    Debug.Log("Right: " + positionValue.x);
        //}
        //else if (positionValue.x <= 0.0f)
        //{
        //    Debug.Log("Left: " + positionValue.y);
        //}