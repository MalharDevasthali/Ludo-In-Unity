using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] commanSteps;
    [SerializeField] private Transform[] blueSteps;
    [SerializeField] private Transform[] redSteps;
    [SerializeField] private Transform[] greenSteps;
    [SerializeField] private Transform[] yellowSteps;
    private int[] safeSpots = { 0, 8, 13, 21, 26, 34, 39, 47 };

    public static MapController instance;

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
    public Vector3 GetPlayerStartingPoint(Pawn.PawnColor color)
    {
        if (color == Pawn.PawnColor.Blue)
            return commanSteps[0].position;
        else if (color == Pawn.PawnColor.Red)
            return commanSteps[13].position;
        else if (color == Pawn.PawnColor.Green)
            return commanSteps[26].position;
        else if (color == Pawn.PawnColor.Yellow)
            return commanSteps[39].position;

        return new Vector3(0, 0, 0);
    }
    public List<Vector3> GetPlayerDestinationPoint(int currentStep, int diceNumber)
    {
        List<Vector3> positions = new List<Vector3>();
        for (int i = 1; i <= diceNumber; i++)
        {
            positions.Add(commanSteps[(currentStep + i) % 52].position);
        }
        return positions;
    }

    public bool IsDestinationSafeSpot(int currentStep)
    {
        for (int i = 0; i < safeSpots.Length; i++)
        {
            if (safeSpots[i] == currentStep)
            {
                return true;
            }
        }
        return false;
    }


}
