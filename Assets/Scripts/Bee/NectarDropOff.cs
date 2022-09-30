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
            onNectarDrop?.Invoke();
        }
    }
}
