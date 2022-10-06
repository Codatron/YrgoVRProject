using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject ctrlImage;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsImage;

    private void Awake()
    {
        mainMenu.SetActive(true);
        ctrlImage.SetActive(false);
        creditsImage.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowCtrl()
    {
        ctrlImage.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ShowCredits()
    {
        creditsImage.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void GoBackMainMenufromCtrl()
    {
        ctrlImage.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void GoBackToMmFromCredits()
    {
        creditsImage.SetActive(false);
        mainMenu.SetActive(true);
    }
}
