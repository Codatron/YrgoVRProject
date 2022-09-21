using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarDropOff : MonoBehaviour
{
    [SerializeField] private SONectar nectarSO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nectarSO.currentNectar < nectarSO.maxNectar)
            {
                Debug.Log("You do not have enough nectar. Go get more!");
            }
            else if (nectarSO.currentNectar >= nectarSO.maxNectar)
            {
                Debug.Log("Welcome back! I see that you've had a busy day little worker bee. The Queen will be proud of you.");
            }
        }
    }
}
