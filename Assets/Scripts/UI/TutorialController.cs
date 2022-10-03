using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject tut1;
    [SerializeField] private GameObject tut2;
    GameManager gameManager;

    private void Awake()
    {
        tut1.SetActive(true);
        tut2.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowNextObject()
    {
        tut1.SetActive(false);
        tut2.SetActive(true);
    }

    public void ChangeGameState()
    {
        gameManager.gameStage = GameStage.BeginGame;
    }
}
