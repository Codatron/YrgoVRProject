using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class SwitchMode : MonoBehaviour
{
    private void Start()
    {
       
    }

    public void StartXRCoroutine()
    {
        //Debug.Log("Initializing XR...");
        //yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        //if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        //{
        //    Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        //}
       
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        
    }

    void StopXR()
    {
        Debug.Log("Stopping XR...");

        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR stopped completely.");
    }


private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StopXR();
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartXRCoroutine();
        }
    }
}
