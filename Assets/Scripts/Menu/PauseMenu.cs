using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPause;
    bool showPauseMenu = false;
    private PausMenu inputActions;

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Menu.MenuPressed.performed += DisplayPauseMenu;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Menu.MenuPressed.performed -= DisplayPauseMenu;
    }

    private void Awake()
    {
        inputActions = new PausMenu();
        Time.timeScale = 1;
    }

    public void DisplayPauseMenu(InputAction.CallbackContext value)
    {
        showPauseMenu = !showPauseMenu;

        if (!showPauseMenu)
        {
            menuPause.SetActive(false);
            Time.timeScale = 1;
        }

        if (showPauseMenu)
        {
            menuPause.SetActive(true);
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
