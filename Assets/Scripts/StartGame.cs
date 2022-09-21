using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartGame : MonoBehaviour
{
    public static event Action beginGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            beginGame?.Invoke();
        }
    }
}

