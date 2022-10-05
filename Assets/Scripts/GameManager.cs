using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void OnNoMoreNectarToJettison();
public delegate void OnAchievementRequirementMet(int collectedNectar);

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
    public static OnAchievementRequirementMet onRequirementMet;

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

    private void Start()
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

        //switch (gameStage)
        //{
        //    case GameStage.Tutorial: BeginTutorial(); 
        //        break;
        //    case GameStage.BeginGame: BeginGame();
        //        break;
        //    case GameStage.GameOver: BeginGameOver();
        //        break;
        //    case GameStage.Flying: BeginFlying();
        //        break;
        //    default:
        //        return;
        //}   
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
    }

    public void AddTotalNectarCollected()
    {
        totalNectarCollected += GetCurrentNectar();
        onRequirementMet?.Invoke(totalNectarCollected);

        if (totalNectarCollected >= maxNectarToCollect)
        {
            Debug.Log("You have fulfilled your duty as a worker bee. Well done.");
            ResetNectar();
            //gameStage = GameStage.GameOver;
            BeginGameOver();

        }

        ResetNectar();
    }

    private void BeginTutorial()
    {
        Time.timeScale = 0.0f;
    }

    private void BeginGame()
    {
        Time.timeScale = 1.0f;
    }

    private void BeginGameOver()
    {
        Time.timeScale = 0.0f;
        gameOverScreen.SetActive(true);
    }

    public void BeginFlying()
    {
        gameOverScreen.SetActive(false);
        //Movment
        Time.timeScale = 1.0f;
    }
}