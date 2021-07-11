using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{

    public static GameService instance;
    public BlueHouse blueHouse;
    public RedHouse redHouse;
    public GreenHouse greenHouse;
    public YellowHouse yellowHouse;
    public bool isPlayingMove;


    public enum Turn
    {
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
            case Turn.blueTurn:
                {
                    currentTurn = Turn.redTurn;
                    Dice.instance.UpdateDiceColor(currentTurn);
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.redTurn:
                {
                    currentTurn = Turn.greenTurn;
                    Dice.instance.UpdateDiceColor(currentTurn);
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.greenTurn:
                {
                    currentTurn = Turn.yellowTurn;
                    Dice.instance.UpdateDiceColor(currentTurn);
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.yellowTurn:
                {
                    currentTurn = Turn.blueTurn;
                    Dice.instance.UpdateDiceColor(currentTurn);
                    Debug.Log(currentTurn);
                    break;
                }
        }
    }
}