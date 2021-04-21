using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject OptionsPanel, CreditsPanel, InstructionsPanel, GameOverPanel, MainMenuPanel, PausePanel, GameSettingsPanel1;

    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameSettingsPanel1.SetActive(false);
        GameController.Instance.state = eState.GAME;
        Console.WriteLine("Start Game menu controller");
    }

    public void StartGameSettings1()
    {
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameSettingsPanel1.SetActive(true);
        GameController.Instance.state = eState.MENU;
        Console.WriteLine("Settings1 menu controller");
    }

    public void Options()
    {
        OptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        Console.WriteLine("Options menu controller");
    }

    public void Instructions()
    {
        InstructionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        Console.WriteLine("Instructions menu controller");
    }

    public void Credits()
    {
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        Console.WriteLine("Credits menu controller");
    }

    public void Back()
    {
        if (GameController.Instance.state == eState.PAUSE)
        {
            BackToPause();
        }
        else
        {
            BackToMenu();
        }
    }

    public void Pause()
    {
        if (GameController.Instance.state == eState.GAME)
        {
            PausePanel.SetActive(true);
            MainMenuPanel.SetActive(false);
            OptionsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
            InstructionsPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            GameController.Instance.state = eState.PAUSE;
        }
    }

    //Back to main menu
    public void BackToMenu()
    {
        //gameObject.SetActive(false);
        MainMenuPanel.SetActive(true);
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameSettingsPanel1.SetActive(false);
        GameController.Instance.state = eState.TITLE;
        Console.WriteLine("BacktoMenu menu controller");
    }

    //Back to pause menu
    public void BackToPause()
    {
        PausePanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameController.Instance.state = eState.PAUSE;
        Console.WriteLine("BacktoPause menu controller");
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        GameController.Instance.state = eState.MENU;
        Console.WriteLine("Gameover menu controller");
    }
    public void ResetApplication()
    {
        SceneManager.LoadScene("Nim");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
