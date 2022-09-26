using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void OnNectarDrop();

public class NectarDropOff : MonoBehaviour
{
    public static OnNectarDrop onNectarDrop;

    [SerializeField] private SONectar nectarSO;
    [SerializeField] private int totalNectarCollected;
    [SerializeField] private GameObject dialouge1;
    [SerializeField] private GameObject dialouge2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nectarSO.currentNectar = 0;
            onNectarDrop?.Invoke();

            // ToDo:
            // Change BeeState back to grounded?

            if (nectarSO.currentNectar >= nectarSO.totalNectar)
            {
                Debug.Log("You have fulfilled your duty as a worker bee. Well done.");
                dialouge1.SetActive(true);
            }

            //if (nectarSO.currentNectar >= nectarSO.maxNectar)
            //{
            //    Debug.Log("Welcome back! I see that you've had a busy day little worker bee. The Queen will be proud of you.");
            //    totalNectarCollected += nectarSO.currentNectar;
            //    nectarSO.currentNectar = 0;
            //}
            
            if (nectarSO.currentNectar < nectarSO.maxNectar)
            {
                Debug.Log("You do not have enough nectar. Go get more!");
                dialouge2.SetActive(true);
            }
        }
    }
}
