using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Singleton
    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            
        }
    }
    #endregion
    
    [Header("Players")]
    string username1 = "Player";
    string username2 = "Jonathan";

    [Header("Other variables")]
    public eState state = eState.TITLE;
    public GameObject gameOverPanel;
    private GameObject turnDisplay;
    public GameObject whiteStone;
    public GameObject blackStone;
    //public GameObject winnerDisplay;
    public System.Random rand = new System.Random();
    public bool forceOnce = true;
    public Grid grid;

    string currentPlayer;
    public TextMeshProUGUI playerTurn;
    public TextMeshProUGUI winner;
    int selectedRow=99999;
    public InputSystem input;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (state == eState.MENU)
        {
            turnDisplay.SetActive(false);

            forceOnce = true;
        }

        //Game is running
        if (state == eState.GAME)
        {
            //If on menu state deactivate

            if (forceOnce == true)
            {
                GameSession();
                
                forceOnce = false;
            }
        }

        

    }

    public void GameSession()
    {
        // Determine who goes first
        currentPlayer = username1;
        Debug.Log(currentPlayer);

        //turnDisplay.SetActive(true);
    }

    public void SetUserName1(string val)
    {
        username1 = val;
    }

    public void SetUserName2(string val)
    {
        username2 = val;
    }
    public void SetStone()
    {
        var stone1 = whiteStone;

        if(username1 == currentPlayer)
        {
            stone1 = whiteStone;
        }
        
        if(username2 == currentPlayer)
        {
            stone1 = blackStone;
        }

        Debug.Log(stone1);
    }

    public void ChangePlayer()
    {

        if(currentPlayer == username1)
        {
            currentPlayer = username2;
            playerTurn.text = username2;
        }
        else if (currentPlayer == username2)
        {
            currentPlayer = username1;
            playerTurn.text = username1;
        }
    }


    public void GameOver()
    {
        if (currentPlayer == username1)
        {
            winner.text = username2 + " has won!";
        }
        else if (currentPlayer == username2)
        {
            winner.text = username1 + " has won!";
        }

        gameOverPanel.SetActive(true);
    }
}

public enum eState
{
    TITLE,
    GAME,
    PAUSE,
    GAMEOVER,
    MENU,
    EXITGAME
}