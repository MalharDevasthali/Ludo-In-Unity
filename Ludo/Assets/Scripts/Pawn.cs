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

    void Start()
    {
        currentState = State.inHouse;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (currentState == State.inHouse)
        {
            if (Dice.instance.GetCurrentDiceNumber() == 6)
            {
                transform.position = MapController.instance.GetBluePlayerStartingPoint();
                transform.localScale = (Vector2)transform.localScale - new Vector2(0.05f, 0.05f);
                GameService.instance.SetCurrentTurn();
            }
        }
        GameService.instance.isPlayingMove = false;
    }
}
