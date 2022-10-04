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

    private VRInput vrInput;

    private void Awake()
    {
        vrInput = new VRInput(rightController, leftController);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Nectar"))
        {
            if (vrInput.GetRightGrip() > 0.1f || vrInput.GetLeftGrip() > 0.1f)
            {
                onNectarPickup?.Invoke();

                //Destroy(other.GetComponent<Collider>());
                //other.GetComponent<MeshRenderer>().enabled = false;
                Destroy(other.gameObject);
            }
        }
    }
}
