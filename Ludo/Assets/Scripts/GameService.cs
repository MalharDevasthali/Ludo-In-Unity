using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{

    public static GameService instance;
    public bool isPlayingMove;


    public enum Turn
    {
        None,
        blueTurn,
        redTurn,
        greenTurn,
        yellowTurn
    }
    public Turn currentTurn;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void SetCurrentTurn()
    {
        switch (currentTurn)
        {
            case Turn.None:
                {
                    currentTurn = Turn.blueTurn;
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.blueTurn:
                {
                    currentTurn = Turn.redTurn;
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.redTurn:
                {
                    currentTurn = Turn.greenTurn;
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.greenTurn:
                {
                    currentTurn = Turn.yellowTurn;
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.yellowTurn:
                {
                    currentTurn = Turn.blueTurn;
                    Debug.Log(currentTurn);
                    break;
                }
        }
    }

    public void SetCurrentTurn(Turn newTurn)
    {
        currentTurn = newTurn;
    }
}