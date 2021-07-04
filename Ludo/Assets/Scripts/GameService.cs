using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{

    public static GameService instance;
    public bool isPlayingMove;


    public enum Turn
    {
        blueTurn,
        redTurn,
        greenTurn,
        yellowTurn
    }
    public Turn currentTurn;
    [SerializeField] private Color[] colors; //0-> Blue , 1->red , 2 -> Green , 3->Yellow

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
                    Dice.instance.UpdateDiceColor(colors[1]);
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.redTurn:
                {
                    currentTurn = Turn.greenTurn;
                    Dice.instance.UpdateDiceColor(colors[2]);
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.greenTurn:
                {
                    currentTurn = Turn.yellowTurn;
                    Dice.instance.UpdateDiceColor(colors[3]);
                    Debug.Log(currentTurn);
                    break;
                }
            case Turn.yellowTurn:
                {
                    currentTurn = Turn.blueTurn;
                    Dice.instance.UpdateDiceColor(colors[0]);
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