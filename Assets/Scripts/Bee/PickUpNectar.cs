using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickUpNectar : MonoBehaviour
{
    public SONectar nectarSO;
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    private float destroyTime;
    private Rigidbody rb;
    private VRInput vrInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        vrInput = new VRInput(rightController, leftController);
    }

    private void Start()
    {
        nectarSO.currentNectar = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (vrInput.GetRightGrip() > 0.1f || vrInput.GetLeftGrip() > 0.1f)
        {
            if (other.gameObject.CompareTag("Nectar"))
            {
                NectarPickUp(1);
                Destroy(other.gameObject);
            }
        }
    }

    private void NectarPickUp(int nectar)
    {
        nectarSO.currentNectar += nectar;
        Debug.Log("I'm collecting nectar:" + nectarSO.currentNectar);

        // Change State???
        IncreaseWeight();
    }

    private void IncreaseWeight()
    {
        rb.mass += 2;
    }
}
