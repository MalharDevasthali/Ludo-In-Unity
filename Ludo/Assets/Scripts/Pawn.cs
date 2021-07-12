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
    private Color initialColor;


    private int steps;
    private int commanStepNumber;
    private Tween blinkingTween = null;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        currentState = State.inHouse;
        initialColor = spriteRenderer.color;
        //  spriteRenderer.material.DOColor(animColor, 0.4f).SetLoops(-1, LoopType.Yoyo);
    }

    public void StartBlinking()
    {
        Debug.Log("StartBlinking");
        if (blinkingTween == null)
            blinkingTween = spriteRenderer.DOColor(animColor, 0.4f).SetLoops(-1, LoopType.Yoyo);
    }
    public void StopBlinking()
    {
        Debug.Log("StopBlinking");
        spriteRenderer.color = initialColor;
        blinkingTween.Kill();
        blinkingTween = null;
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

        StopBlinkingAnimationForAllPawns();
        for (int i = 0; i < Dice.instance.GetCurrentDiceNumber(); i++)
        {
            transform.DOJump(positions[i], 0.5f, 1, 0.5f);
            await Task.Delay(500);
        }
        commanStepNumber = (commanStepNumber + Dice.instance.GetCurrentDiceNumber()) % 52;
        steps += Dice.instance.GetCurrentDiceNumber();

        if (Dice.instance.GetCurrentDiceNumber() != 6)
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
            StopBlinkingAnimationForAllPawns();
            SetCommanStepNumber();
        }

    }
    private void StopBlinkingAnimationForAllPawns()
    {
        switch (color)
        {
            case PawnColor.Blue:
                {
                    GameService.instance.GetBlueHouse().StopMovePlayingAnimation();
                }
                break;
            case PawnColor.Red:
                {
                    GameService.instance.GetRedHouse().StopMovePlayingAnimation();
                }
                break;
            case PawnColor.Green:
                {
                    GameService.instance.GetGreenHouse().StopMovePlayingAnimation();
                }
                break;
            case PawnColor.Yellow:
                {
                    GameService.instance.GetYellowHouse().StopMovePlayingAnimation();
                }
                break;
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
