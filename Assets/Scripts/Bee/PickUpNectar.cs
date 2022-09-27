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

    private HandContoller handController;
    private VRInput vrInput;
    private BeeStateSwitcher stateSwitcher; 

    private void Awake()
    {
        handController = GetComponent<HandContoller>();
        vrInput = new VRInput(rightController, leftController);
        stateSwitcher = new BeeStateSwitcher(BeeState.Grounded);
    }

    private void Start()
    {
        nectarSO.currentNectar = 0;
    }

    private void Update()
    {
        if (nectarSO.currentNectar != 0)
        {
            stateSwitcher.CurrentBeeState = BeeState.CarryingPollen;
        }
        else
        {
            stateSwitcher.CurrentBeeState = BeeState.Grounded;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Nectar"))
        {
            if (vrInput.GetRightGrip() > 0.1f || vrInput.GetLeftGrip() > 0.1f)
            {
                NectarPickUp(1);
                handController.IncreaseDrag(1);
                Destroy(other.gameObject);
            }
        }
    }

    private void NectarPickUp(int nectar)
    {
        nectarSO.currentNectar += nectar;
        Debug.Log("I'm collecting nectar: " + nectarSO.currentNectar);
    }
}
