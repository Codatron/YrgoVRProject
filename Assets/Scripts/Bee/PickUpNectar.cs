using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public delegate void OnNectarPickup();

public class PickUpNectar : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public static OnNectarPickup onNectarPickup;

    [SerializeField] float dragIncrease;
    private HandContoller handController;
    private VRInput vrInput;

    private void Awake()
    {
        handController = GetComponent<HandContoller>();
        vrInput = new VRInput(rightController, leftController);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Nectar"))
        {
            if (vrInput.GetRightGrip() > 0.1f || vrInput.GetLeftGrip() > 0.1f)
            {
                onNectarPickup?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}
