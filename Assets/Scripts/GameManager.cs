using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void OnNoMoreNectarToJettison();
    public enum GameStage
    {
        Tutorial,
        BeginGame,
        GameOver,
        Flying,
    }

public class GameManager : MonoBehaviour
{
    public GameStage gameStage;

    public static event Action startGame;


    public static OnNoMoreNectarToJettison onNoMoreNectarToJettison;
    [SerializeField] private int currentNectar;
    [SerializeField] private int totalNectarCollected;
    [SerializeField] private int maxNectarToCollect;

    private int nectarValue;
    private BeeStateSwitcher stateSwitcher;

    [SerializeField] private GameObject tutText;
    [SerializeField] private GameObject gameOverScreen;

    private HandContoller handContoller;


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
        gameStage = GameStage.Tutorial;
        Time.timeScale = 1.0f;
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

        switch (gameStage)
        {
            case GameStage.Tutorial: BeginTutorial(); 
                break;
            case GameStage.BeginGame: BeginGame();
                break;
            case GameStage.GameOver: BeginGameOver();
                break;
            case GameStage.Flying: BeginFlying();
                break;
            default:
                return;
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
            gameStage = GameStage.GameOver;
        }

        ResetNectar();
    }

    private void BeginTutorial()
    {
        //handContoller.stateSwitcher.CurrentBeeState = BeeState.NoMovement;
        Time.timeScale = 0.0f;
        //tutText.SetActive(true);
    }

    private void BeginGame()
    {
        //handContoller.stateSwitcher.CurrentBeeState = BeeState.Grounded;
        Time.timeScale = 1.0f;
    }

    private void BeginGameOver()
    {
        Time.timeScale = 0.0f;
        //IFnecktar ui
        gameOverScreen.SetActive(true);
        //IFNot Necktar?
    }

    private void BeginFlying()
    {
        //Movment
        handContoller.stateSwitcher.CurrentBeeState = BeeState.Grounded;
        //disconect neckar pick up and gameover
    }

}
