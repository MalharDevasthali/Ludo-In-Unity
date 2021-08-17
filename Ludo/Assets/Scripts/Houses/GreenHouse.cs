using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHouse : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Pawn[] greenPawns;
    private GameObject test;

    public bool isHouseFull()
    {
        for (int i = 0; i < greenPawns.Length; i++)

        {
            if (greenPawns[i].currentState == Pawn.State.onBoard)
            {
                return false;
            }
        }
        return true;
    }

    public void PlayMovePlayingAnimation()
    {
        for (int i = 0; i < greenPawns.Length; i++)
        {
            if (greenPawns[i].currentState == Pawn.State.onBoard || Dice.instance.GetCurrentDiceNumber() == 6)
                greenPawns[i].StartBlinking();
        }
    }
    public void StopMovePlayingAnimation()
    {
        for (int i = 0; i < greenPawns.Length; i++)
        {
            greenPawns[i].StopBlinking();
        }
    }

}
