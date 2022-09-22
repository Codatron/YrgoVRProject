using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarDropOff : MonoBehaviour
{
    [SerializeField] private SONectar nectarSO;
    [SerializeField] private int totalNectarCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (totalNectarCollected >= nectarSO.totalNectar)
            {
                Debug.Log("You have fulfilled your duty as a worker bee. Well done.");
            }
            else if (nectarSO.currentNectar >= nectarSO.maxNectar)
            {
                Debug.Log("Welcome back! I see that you've had a busy day little worker bee. The Queen will be proud of you.");
                totalNectarCollected += nectarSO.currentNectar;
                nectarSO.currentNectar = 0;
            }
            else if (nectarSO.currentNectar < nectarSO.maxNectar)
            {
                Debug.Log("You do not have enough nectar. Go get more!");
            }
        }
    }
}
