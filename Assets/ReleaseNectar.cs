using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ReleaseNectar : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    
    private PickUpNectar pickUpnectarScr;

    private void Awake()
    {
        pickUpnectarScr = GetComponent<PickUpNectar>();
    }

    private void OnEnable() => rightController.uiPressAction.action.performed += ReleaseNectarLoad;

    private void OnDisable() => rightController.uiPressAction.action.performed -= ReleaseNectarLoad;

    private void ReleaseNectarLoad(InputAction.CallbackContext ctx) => pickUpnectarScr.SetCurrentNectar();

}
