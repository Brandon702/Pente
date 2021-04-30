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
    public TextMeshProUGUI player1Display;
    public TextMeshProUGUI player2Display;
    public TextMeshProUGUI eventDisplay;
    public InputSystem input;
    public static int size = 20;
    public static int[] row = new int[size];
    public static int[] col = new int[size];
    public int[,] gameBoard = new int[size,size];
    public AudioSource sfx;

    public MainMenuController mainMenuController;
    public Timer timer;

    void Start()
    {
        grid = new Grid(size, size, 2.09f, new Vector3(0, 0));
        timer.StartTimer();
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
            timer.UpdateTime();
            if(timer.timerText.text == "0:10:00")
            {
                if(currentPlayer.Equals(username2))
                {
                    currentPlayer = username1;
                    playerTurn.text = username1 + "'s turn";
                    timer.StartTimer();
                }    
                else if(currentPlayer.Equals(username1))
                {
                    currentPlayer = username2;
                    playerTurn.text = username2 + "'s turn";
                    timer.StartTimer();
                }
            }

            if (forceOnce == true)
            {
                GameSession();
                
                forceOnce = false;
            }
            grid.GetMouseXY(out int x, out int y);

            if(Input.GetKeyDown(KeyCode.P))
            {
                mainMenuController.Pause();
                timer.StopTimer();
            }

            if (Input.GetMouseButtonDown(0))
            {
                sfx.Play();
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
                timer.StartTimer();
                CaptureCheck();
                if (Tria() != 0 || Tessera() != 0)
                {
                    Annoucement();
                }
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
                        GameOver();
                        mainMenuController.GameOver();
                    }
                    //break;
                }
            }
        }

        return winner;
    }       

    //Traditional 1 value check
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
        Tria();
        Tessera();
    }

    public int Tria()
    {
        int player = 0;
        for (int y = 0; y < 19; y++)
        {
            for (int x = 0; x < 19; x++)
            {
                if (gameBoard[x, y] != 0)
                {
                    int marker = gameBoard[x, y];
                    bool success = CheckHorizontal(marker, x, y, 3) || CheckVertical(marker, x, y, 3) || CheckDiagonalLeft(marker, x, y, 3) || CheckDiagonalRight(marker, x, y, 3);
                    if (success)
                    {
                        player = marker;
                        //Announce
                        if (marker == 1)
                        {
                            eventDisplay.text = username1 + " has achieved Tria";
                        }
                        else if (marker == 2)
                        {
                            eventDisplay.text = username2 + " has achieved Tria";
                        }
                    }
                    //break;
                }
            }
        }

        return player;
    }

    public int Tessera()
    {
        int player = 0;
        for (int y = 0; y < 19; y++)
        {
            for (int x = 0; x < 19; x++)
            {
                if (gameBoard[x, y] != 0)
                {
                    int marker = gameBoard[x, y];
                    bool success = CheckHorizontal(marker, x, y, 4) || CheckVertical(marker, x, y, 4) || CheckDiagonalLeft(marker, x, y, 4) || CheckDiagonalRight(marker, x, y, 4);
                    if (success)
                    {
                        player = marker;
                        //Announce

                        if (marker == 1)
                        {
                            eventDisplay.text = username1 + " has achieved Tessera";
                        }
                        else if (marker == 2)
                        {
                            eventDisplay.text = username2 + " has achieved Tessera";
                        }
                    }
                    //break;
                }
            }
        }

        return player;
    }

    public void GameSession()
    {
        // Determine who goes first
        currentPlayer = username1;
        playerTurn.text = username1 + "'s turn";
        player1Display.text = username1;
        player2Display.text = username2;
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
            playerTurn.text = username2 + "'s turn";
        }
        else if (currentPlayer == username2)
        {
            currentPlayer = username1;
            playerTurn.text = username1 + "'s turn";
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
        eventDisplay.text = "None";

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
