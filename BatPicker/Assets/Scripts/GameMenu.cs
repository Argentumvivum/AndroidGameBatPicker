using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {

    public GameObject menu;
    public GameObject gameUI;
    public GameObject scoreDisplay;
    public GameObject healthDisplay;
    private GameManager gameManager;
    private Manager manager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        manager = FindObjectOfType<Manager>();
    }

    public void RestartGame()
    {
        gameManager.UnPauseGame();
        gameManager.StartGame();
    }

    public void QuitGame()
    {
        gameManager.UnPauseGame();
        gameManager.ReturnToMenu();
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        scoreDisplay.SetActive(false);
        healthDisplay.SetActive(false);
        gameUI.SetActive(false);
        gameManager.PauseGame();
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        scoreDisplay.SetActive(true);
        healthDisplay.SetActive(true);
        gameUI.SetActive(true);
        gameManager.UnPauseGame();
    }
}
