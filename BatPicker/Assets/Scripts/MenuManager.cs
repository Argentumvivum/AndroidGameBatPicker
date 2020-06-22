using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    private GameManager manager;
    public GameObject credits;
    public GameObject menu;
    public GameObject mute;
    public Toggle muteToggle;
    public GameObject instructions;
    public GameObject instruction1;
    public GameObject instruction2;
    public GameObject instruction3;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        muteToggle.isOn = manager.options.sfx;
    }

    public void StartGame()
    {
        manager.StartGame();
    }

    public void ViewCredits()
    {
        credits.SetActive(true);
        menu.SetActive(false);
        mute.SetActive(false);
    }

    public void Return()
    {
        credits.SetActive(false);
        menu.SetActive(true);
        mute.SetActive(true);
    }

    public void QuitGame()
    {
        manager.QuitGame();
    }

    public void HyperlingButton()
    {
        Application.OpenURL("https://www.youtube.com/user/LordSivo");
    }

    public void MuteGame()
    {
        manager.options.sfx = muteToggle.isOn;
        manager.options.SaveOptions();
    }

    public void ViewInstruction()
    {
        menu.SetActive(false);
        mute.SetActive(false);
        instructions.SetActive(true);
        instruction1.SetActive(true);
    }

    public void GoFrom1To2()
    {
        instruction1.SetActive(false);
        instruction2.SetActive(true);
    }

    public void GoFrom2To3()
    {
        instruction2.SetActive(false);
        instruction3.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructions.SetActive(false);
        instruction1.SetActive(false);
        instruction2.SetActive(false);
        instruction3.SetActive(false);
        menu.SetActive(true);
        mute.SetActive(true);
    }
}
