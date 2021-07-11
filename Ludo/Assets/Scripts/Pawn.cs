using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using DG.Tweening;

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
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color animColor;


    private int steps;
    private int commanStepNumber;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        currentState = State.inHouse;
        //  spriteRenderer.material.DOColor(animColor, 0.4f).SetLoops(-1, LoopType.Yoyo);
    }

    public void PlayPlayerPlayingAnimation()
    {
        Debug.Log("PlayPlayerPlayingAnimation");
        // spriteRenderer.material.DOColor(animColor, 0.4f).SetLoops(-1, LoopType.Yoyo);
        //   spriteRenderer.material.color = animColor;
    }

    private void OnMouseDown()
    {
        if (CanPlayMove())
        {
            MovePawn();
        }
    }

    private bool CanPlayMove()
    {
        return (GameService.instance.currentTurn == GameService.Turn.blueTurn && color == PawnColor.Blue)
                    || (GameService.instance.currentTurn == GameService.Turn.redTurn && color == PawnColor.Red)
                    || (GameService.instance.currentTurn == GameService.Turn.greenTurn && color == PawnColor.Green)
                    || (GameService.instance.currentTurn == GameService.Turn.yellowTurn && color == PawnColor.Yellow);
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

        }
    }

    private async void OnBoard()
    {
        GameService.instance.isPlayingMove = false;

        List<Vector3> positions = MapController.instance.GetPlayerDestinationPoint(commanStepNumber, Dice.instance.GetCurrentDiceNumber());

        for (int i = 0; i < Dice.instance.GetCurrentDiceNumber(); i++)
        {
            transform.DOJump(positions[i], 0.5f, 1, 0.5f);
            await Task.Delay(500);
        }
        commanStepNumber = (commanStepNumber + Dice.instance.GetCurrentDiceNumber()) % 52;
        steps += Dice.instance.GetCurrentDiceNumber();
        GameService.instance.SetNextTurn();
    }

    private void InHouse()
    {

        if (Dice.instance.GetCurrentDiceNumber() == 6)
        {
            GameService.instance.isPlayingMove = false;
            transform.position = MapController.instance.GetPlayerStartingPoint(color);
            transform.localScale = (Vector2)transform.localScale - new Vector2(0.05f, 0.05f);
            currentState = State.onBoard;
            steps = 0;
            GameService.instance.SetNextTurn();
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
