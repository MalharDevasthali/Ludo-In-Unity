using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHouse : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Pawn[] greenPawns;

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

}
