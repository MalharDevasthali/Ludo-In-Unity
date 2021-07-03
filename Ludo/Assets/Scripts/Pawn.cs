using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    // Start is called before the first frame update
    public enum PawnColor
    {
        Blue,
        Red,
        Green,
        Yellow
    }
    public enum State
    {
        inHouse,
        onSafeSquare,
        onBoard,
    }
    public PawnColor color;
    public State currentState;

    private int steps;
    private int commanStepNumber;

    void Start()
    {
        currentState = State.inHouse;
    }

    private void OnMouseDown()
    {
        if (GameService.instance.currentTurn == GameService.Turn.blueTurn)
        {
            MovePawn();
        }
    }
    private void MovePawn()
    {
        if (GameService.instance.isPlayingMove)
        {
            if (currentState == State.inHouse)
            {
                InHouse();
            }
            else if (currentState == State.onBoard)
            {
                OnBoard();
            }
            GameService.instance.isPlayingMove = false;
        }
    }

    private void OnBoard()
    {
        commanStepNumber += Dice.instance.GetCurrentDiceNumber();
        steps += Dice.instance.GetCurrentDiceNumber();
        transform.position = MapController.instance.GetPlayerDestinationPoint(commanStepNumber);
    }

    private void InHouse()
    {

        if (Dice.instance.GetCurrentDiceNumber() == 6)
        {
            transform.position = MapController.instance.GetPlayerStartingPoint(color);
            transform.localScale = (Vector2)transform.localScale - new Vector2(0.05f, 0.05f);
            currentState = State.onBoard;
            steps = 0;
            //GameService.instance.SetCurrentTurn();
            SetCommanStepNumber();
        }

    }

    private void SetCommanStepNumber()
    {
        if (color == PawnColor.Blue)
        {
            commanStepNumber = 0;
        }
        else if (color == PawnColor.Red)
        {
            commanStepNumber = 13;
        }
        else if (color == PawnColor.Green)
        {
            commanStepNumber = 26;
        }
        else if (color == PawnColor.Yellow)
        {
            commanStepNumber = 39;
        }
    }
}
