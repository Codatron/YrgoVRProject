using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void OnNectarDrop();

public class NectarDropOff : MonoBehaviour
{
    public static OnNectarDrop onNectarDrop;

    [SerializeField] private int totalNectarCollected;
    [SerializeField] private int maxNectarToCollect;
    //[SerializeField] private GameObject dialouge1;
    //[SerializeField] private GameObject dialouge2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("I'm home");

            PickUpNectar pickUpNectarScr = other.GetComponent<PickUpNectar>();
            totalNectarCollected += pickUpNectarScr.GetCurrentNectar();
            pickUpNectarScr.ResetNectar();

            if (totalNectarCollected >= maxNectarToCollect)
            {
                Debug.Log("You have fulfilled your duty as a worker bee. Well done.");
                // Game Over - Win Screen
                //dialouge1.SetActive(true);
            }
        }
    }
}
