using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickUpNectar : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    [SerializeField] float dragIncrease;
    private int currentNectar;
    private HandContoller handController;
    private VRInput vrInput;
    private BeeStateSwitcher stateSwitcher;
    private int nectarAmount = 1;


    private void Awake()
    {
        handController = GetComponent<HandContoller>();
        vrInput = new VRInput(rightController, leftController);
        stateSwitcher = new BeeStateSwitcher(BeeState.Grounded);
    }

    private void Start()
    {
        currentNectar = 0;
    }

    private void Update()
    {
        if (currentNectar != 0)
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
                NectarPickUp(nectarAmount);
                handController.IncreaseDrag(dragIncrease);
                Destroy(other.gameObject);
            }
        }
    }

    private void NectarPickUp(int nectar)
    {
        //nectarSO.currentNectar += nectar;
        //Debug.Log("I'm collecting nectar: " + nectarSO.currentNectar);
        currentNectar += nectar;
        Debug.Log("Current Nectar " + currentNectar);
    }

    public int GetCurrentNectar()
    {
        return currentNectar;
    }

    public void SetCurrentNectar()
    {
        if (currentNectar > 0)
        {
            currentNectar -= 1;
        }
        Debug.Log("Current Nectar " + currentNectar);
    }

    public void ResetNectar()
    {
        currentNectar = 0;
    }
}
