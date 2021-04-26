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
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {

        }
    }
    #endregion

    [Header("Players")]
    public string username1 = "Player";
    public string username2 = "Jonathan";

    [Header("Other variables")]
    public eState state = eState.TITLE;
    public GameObject gameOverPanel;
    private GameObject turnDisplay;
    public GameObject whiteMarker, blackMarker;
    public bool forceOnce = true;
    public Grid grid;

    public string currentPlayer;
    public TextMeshProUGUI playerTurn;
    public TextMeshProUGUI winner;
    public InputSystem input;
    public static int[] row = new int[19];
    public static int[] col = new int[19];
    public int[,] gameBoard = new int[19,19];

    public MainMenuController mainMenuController;

    void Start()
    {
        grid = new Grid(19, 19, 2.09f, new Vector3(0, 0));
    }

    void Update()
    {
        if (state == eState.MENU)
        {
            //turnDisplay.SetActive(false);

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
            grid.GetMouseXY(out int x, out int y);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = grid.GetWorldCellPosition(x, y);
                int marker = 0;
                if (currentPlayer.Equals(username1))
                {
                    Instantiate(whiteMarker, position, Quaternion.identity);
                    marker = 1;
                    //Add playervalue to 2D array here
                }
                else if (currentPlayer.Equals(username2))
                {
                    Instantiate(blackMarker, position, Quaternion.identity);
                    marker = 2;
                    //Add playervalue to 2D array here
                }
                //Add a value to a 2D array based on the current player in the position that was used
                AddToBoard(marker, x, y);
                int winner = VictoryCheck();
                CaptureCheck();
                Annoucement();
                ChangePlayer();
            }
        }
    }
    public void AddToBoard(int marker, int x, int y)
    {
        gameBoard[x,y] = marker;
    }
    public int VictoryCheck()
    {
        int winner = 0;
        for (int y = 0; y < 19; y++)
        {
            for (int x = 0; x < 19; x++)
            {
                if (gameBoard[x,y] != 0)
                {
                    int marker = gameBoard[x, y];
                    bool success = CheckHorizontal(marker, x, y, 5) || CheckVertical(marker, x, y, 5) || CheckDiagonalLeft(marker, x, y, 5) || CheckDiagonalRight(marker, x, y, 5);
                    if (success)
                    {
                        winner = marker;
                        Debug.Log("Winner: " +  marker);
                        mainMenuController.GameOver();
                    }
                    //break;
                }
            }
        }

        return winner;
    }       
    bool CheckHorizontal(int marker, int x, int y, int size)
    {
        //if (x < 4 || x > 15) return false;

        bool success = true;
        for (int cx = 0; cx < size; cx++)
        {
            if (gameBoard[x + cx, y] != marker)
            {
                success = false;
                break;
            }
        }

        return success;
    }

    bool CheckVertical(int marker, int x, int y, int size)
    {
        //if (y < 4 || y > 15) return false;

        bool success = true;
        for (int cy = 0; cy < size; cy++)
        {
            if (gameBoard[x, y + cy] != marker)
            {
                success = false;
                break;
            }
        }

        return success;
    }

    bool CheckDiagonalLeft(int marker, int x, int y, int size)
    {
        bool success = true;
        for(int cy=0, cx=0; cy < size && cx < size; cy++, cx++)
        {
            if (gameBoard[x + cx, y + cy] != marker)
            {
                success = false;
                break;
            }
        }

        return success;
    }

    bool CheckDiagonalRight(int marker, int x, int y, int size)
    {
        bool success = true;
        for (int cy = 0, cx = 0; cy < size && cx < size; cy--, cx++)
        {
            if (gameBoard[x + cx, y + cy] != marker)
            {
                success = false;
                break;
            }
        }

        return success;
    }

    public void CaptureCheck()
    {
        //Check in 4 directions for a 4x1 where index [0] & [3] are the same & [1] & [2] are the same
    }

    public void Annoucement()
    {
        //Check in 4 directions for a 3x1 or 4x1 & display that information

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
        var stone1 = whiteMarker;

        if(currentPlayer.Equals(username1))
        {
            stone1 = whiteMarker;
        }
        
        if(currentPlayer.Equals(username2))
        {
            stone1 = blackMarker;
        }

        Debug.Log(stone1);
    }

    public void ChangePlayer()
    {

        if(currentPlayer == username1)
        {
            currentPlayer = username2;
            //playerTurn.text = username2;
        }
        else if (currentPlayer == username2)
        {
            currentPlayer = username1;
            //playerTurn.text = username1;
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
