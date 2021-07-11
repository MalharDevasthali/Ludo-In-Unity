using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIService : MonoBehaviour
{
    [SerializeField] Dice dice;
    [SerializeField] RectTransform dicePosition;
    [SerializeField] Button startButton;

    public void OnButtonClickStart()
    {
        Instantiate(dice.gameObject, dicePosition);
        Destroy(startButton.gameObject);
    }
}
