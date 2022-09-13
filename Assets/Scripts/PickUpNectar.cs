using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNectar : MonoBehaviour
{
    public SONectar sONectar;
    private float destroyTime;

    [SerializeField]
    private float maxSpeed;

    public Rigidbody playerRB;
    public ParticleSystem nectarParticleSystem;

    private void Start()
    {
        destroyTime = 0.2f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Flower")) //&& playerRB.velocity.magnitude < maxSpeed) //ar det har ratt?
        {
            nectarParticleSystem.Play(); //Hur fa det att bara spela en gang, loser hastigheten det?
        }

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

    }
    private void LeaveNectar()
    {
        sONectar.currentNectar = 0;
    }

    //void GetParticalEffect()
    //{

    //    GameObject nectarPS = ObjectPoolPatricalEffectNectar.SharedInstance.GetPooledObject();

    //    if (nectarPS != null)
    //    {
    //        //nectarPS.transform.position = turret.transform.postion;
    //        //nectarPS.transform.rotation = turret.transform.rotation;
    //        nectarPS.SetActiv();
            

    //    }


    //    nectarPS.setActiv(false);

    //}

}
