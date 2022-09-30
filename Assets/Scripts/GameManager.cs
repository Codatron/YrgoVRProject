using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnNoMoreNectarToJettison();

public class GameManager : MonoBehaviour
{
    public static OnNoMoreNectarToJettison onNoMoreNectarToJettison;
    [SerializeField] private int currentNectar;
    [SerializeField] private int totalNectarCollected;
    [SerializeField] private int maxNectarToCollect;

    private int nectarValue;
    private BeeStateSwitcher stateSwitcher;

    private void OnEnable()
    {
        PickUpNectar.onNectarPickup += AddNectar;
        ReleaseNectar.onNectarReleased += SetCurrentNectar;
        NectarDropOff.onNectarDrop += AddTotalNectarCollected;
    }

    private void OnDisable()
    {
        PickUpNectar.onNectarPickup -= AddNectar;
        ReleaseNectar.onNectarReleased -= SetCurrentNectar;
        NectarDropOff.onNectarDrop -= AddTotalNectarCollected;
    }

    private void Awake()
    {
        stateSwitcher = new BeeStateSwitcher(BeeState.Grounded);
    }

    void Start()
    {
        nectarValue = 1;
        currentNectar = 0;
        maxNectarToCollect = 10;
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

    private void AddNectar()
    {
        currentNectar += nectarValue;
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
            currentNectar -= nectarValue;
            onNoMoreNectarToJettison?.Invoke();
        }
        else
        {
            Debug.Log("No more nectar to drop.");
            return;
        }

        Debug.Log("Current Nectar " + currentNectar);
    }

    public void ResetNectar()
    {
        currentNectar = 0;
        //handController.RestoreDrag();

    }

    public void AddTotalNectarCollected()
    {
        totalNectarCollected += GetCurrentNectar();

        if (totalNectarCollected >= maxNectarToCollect)
        {
            Debug.Log("You have fulfilled your duty as a worker bee. Well done.");
            ResetNectar();
            // Game Over - Win Screen
            //dialouge1.SetActive(true);
        }

        ResetNectar();
    }
}
