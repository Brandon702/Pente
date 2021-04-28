using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject CreditsPanel;
    public GameObject InstructionsPanel;
    public GameObject GameOverPanel;
    public GameObject MainMenuPanel;
    public GameObject PausePanel;
    public GameObject GameSettingsPanel1;
    public GameController gameController;

    public GameObject blackMarker;
    public GameObject whiteMarker;
    public Timer timer;

    private void Start()
    {
        gameObject.SetActive(true);
        GameController.Instance.state = eState.TITLE;
    }
    public void StartGame()
    {
        timer.StartTimer();
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameSettingsPanel1.SetActive(false);
        GameOverPanel.SetActive(false);
        GameController.Instance.state = eState.GAME;
        Debug.Log("Start Game");
    }

    public void StartGameSettings1()
    {
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameSettingsPanel1.SetActive(true);
        GameController.Instance.state = eState.MENU;
        Debug.Log("Settings1 menu");
    }

    public void Options()
    {
        OptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        Debug.Log("Options menu");
    }

    public void Instructions()
    {
        InstructionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        Debug.Log("Instructions menu");
    }

    public void Credits()
    {
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        PausePanel.SetActive(false);
        Debug.Log("Credits menu");
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
        ResetBoard();
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
        timer.StopTimer();
        GameOverPanel.SetActive(true);
        ResetBoard();
        GameController.Instance.state = eState.MENU;
        Console.WriteLine("Gameover menu controller");
    }

    public void ResetBoard()
    {
        //Clear board
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Marker");
        foreach (GameObject Marker in markers)
        {
            GameObject.Destroy(Marker);
        }

        //If game is buggy, its literally this:
        for (int i = 0; i < gameController.gameBoard.Length; i++)
        {
            Array.Clear(gameController.gameBoard, i, gameController.gameBoard.Length - 1);

        }
        gameController.currentPlayer = gameController.username1;
    }
    public void ResetApplication()
    {
        SceneManager.LoadScene("Pente");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
