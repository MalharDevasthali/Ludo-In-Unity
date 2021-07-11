using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHouse : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Pawn[] redPawns;
    [SerializeField] private TempBlinked[] tempBlinkeds;

    public bool isHouseFull()
    {
        for (int i = 0; i < redPawns.Length; i++)

        {
            if (redPawns[i].currentState == Pawn.State.onBoard)
            {
                return false;
            }
        }
        return true;
    }
    public void PlayMovePlayingAnimation()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("Blink1");
            tempBlinkeds[i].Blink();
        }
    }
}
