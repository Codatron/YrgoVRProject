using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

// What this script does:
// Detects the connection status of our XR devices.
// Returns the name and characteristics of the connected devices to the console.
// Blueprint for accessing controllers and listening for their inputs

public class InputReader : MonoBehaviour
{
    [SerializeField] private List<InputDevice> inputDevices = new List<InputDevice>();

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

    private void InitializeInputReader()
    {
        InputDevices.GetDevices(inputDevices);

        foreach (var item in inputDevices)
        {
            Debug.Log(item.name + " " + item.characteristics);
        }
    }

    private void OnDeviceConnected(InputDevice device)
    {
        Debug.Log("Device connection successful: " + device.name);
    }

    private void OnDeviceDisconnected(InputDevice device)
    {
        Debug.Log("Device disconnected: " + device.name);
    }
}
