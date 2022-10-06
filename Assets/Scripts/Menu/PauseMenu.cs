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
    public GameObject howToPlayObject;
    [SerializeField] private AudioClip menuClick;
    [SerializeField] private AudioSource audioSource;

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
        AudioListener.pause = false;
        inputActions = new PausMenu();
        //menuPause.SetActive(false);
    }

    public void DisplayPauseMenu(InputAction.CallbackContext value)
    {
        showPauseMenu = !showPauseMenu;

        if (!showPauseMenu)
        {
            menuPause.SetActive(false);
            Time.timeScale = 1.0f;
            AudioListener.pause = false;
        }

        if (showPauseMenu)
        {
            menuPause.SetActive(true);
            Time.timeScale = 0.0f;
            AudioListener.pause = true;
        }
    }

    public void RestartGame()
    {
        PlayMenuSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ExitGame()
    {
        PlayMenuSound();
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        PlayMenuSound();
        SceneManager.LoadScene(0);
    }

    public void HowToPlay()
    {
        PlayMenuSound();
        howToPlayObject.SetActive(true);
        menuPause.SetActive(false);

    }

    public void GoBackToPause()
    {
        PlayMenuSound();
        howToPlayObject.SetActive(false);
        menuPause.SetActive(true);
    }

    public void PlayMenuSound()
    {
        SFXHandler.PlayOneShot(audioSource, menuClick);
    }

    public void GoBackToGame()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
    }
}
