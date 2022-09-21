using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNectar : MonoBehaviour
{
    public SONectar nectarSO;

    private float destroyTime;
    private Rigidbody playerRB;

    private void Start()
    {
        destroyTime = 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nectar"))
        {
            Debug.Log("I'm collecting nectar");
            NectarPickUp(1);
            Destroy(other.gameObject, destroyTime);
        }

        //if (other.gameObject.CompareTag("LeaveNectar"))
        //{
        //    LeaveNectar();
        //}
    }

    private void NectarPickUp(int nectar)
    {
        nectarSO.currentNectar += nectar;
        //playerRB.drag += 2;
    }

    //private void LeaveNectar()
    //{
    //    sONectar.currentNectar = 0;
    //}

}
