using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNectar : MonoBehaviour
{
    public SONectar sONectar;
    private float destroyTime;
    public Rigidbody playerRB;

    private void Start()
    {
        destroyTime = 0.2f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Nectar"))
        {
            NectarPickUp(1);
            Destroy(other.gameObject, destroyTime);
        }

        if (other.gameObject.CompareTag("LeaveNectar"))
        {
            LeaveNectar();
        }
    }

    private void NectarPickUp(int nectar)
    {
        sONectar.currentNectar += nectar;
        playerRB.drag += 2;

        //particeleffect
    }
    private void LeaveNectar()
    {
        sONectar.currentNectar = 0;
    }

}
