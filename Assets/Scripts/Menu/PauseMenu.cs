using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPause;
    bool showPauseMenu = true;
    private PausMenu inputActions;

    void Start()
    {
        DisplayPauseMenu();
    }

    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private void Awake()
    {
        inputActions = new PausMenu();
    }
    private void Update()
    {
        if (inputActions.Menu.MenuPressed.triggered)
        {
            DisplayPauseMenu();

        }
    }

    public void DisplayPauseMenu()
    {
        if (showPauseMenu)
        {
            menuPause.SetActive(false);
            showPauseMenu = false;
            Time.timeScale = 1;
        }

        if (!showPauseMenu)
        {
            menuPause.SetActive(true);
            showPauseMenu = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
