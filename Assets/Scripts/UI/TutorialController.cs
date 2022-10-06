using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject tut1;
    [SerializeField] private GameObject tut2;
    [SerializeField] private GameObject tut3;
    GameManager gameManager;
    PauseMenu pauseMenu;

    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        tut1.SetActive(true);
        tut2.SetActive(false);
        tut3.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowNextObject()
    {
        pauseMenu.PlayMenuSound();
        tut1.SetActive(false);
        tut2.SetActive(true);
    }

    public void ShowNextObject2()
    {
        pauseMenu.PlayMenuSound();
        tut2.SetActive(false);
        tut3.SetActive(true);
    }

    public void ChangeGameState()
    {
        pauseMenu.PlayMenuSound();
        //gameManager.gameStage = GameStage.BeginGame;
        Time.timeScale = 1.0f;
        tut3.SetActive(false);
    }
}
