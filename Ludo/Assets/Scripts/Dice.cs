using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using System;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{

    public static Dice instance;
    [SerializeField] private Sprite[] diceImages;
    [SerializeField] private Color[] colors; //0-> Blue , 1->red , 2 -> Green , 3->Yellow

    public bool isTesting;
    public int DiceNumber;
    private Image diceButtonImage;
    private Animator animator;
    private int currentDiceNumber;

    // Start is called before the first frame update
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
    void Start()
    {
        diceButtonImage = GetComponent<Image>();
        animator = GetComponent<Animator>();
        RandomizeDiceAndTurn();

    }

    private void RandomizeDiceAndTurn()
    {
        //  int randDice = UnityEngine.Random.Range(0, 6);
        int randTurn = UnityEngine.Random.Range(0, 4);
        ///  diceButtonImage.sprite = diceImages[randDice];

        Type type = typeof(GameService.Turn);
        Array values = type.GetEnumValues();
        int index = UnityEngine.Random.Range(0, values.Length);
        GameService.instance.currentTurn = (GameService.Turn)values.GetValue(index);

        UpdateDiceColor(GameService.instance.currentTurn);
    }

    public async void ShuffleDice()
    {
        if (GameService.instance.isPlayingMove)
            return;

        int rand = await RollingAnimationEffect(); //2 Sec Delay

        if (!isTesting)
            currentDiceNumber = rand + 1;
        else
        {
            currentDiceNumber = DiceNumber;
            diceButtonImage.sprite = diceImages[currentDiceNumber - 1];
        }


        if (isCurrentHouseFull() && currentDiceNumber != 6)
        {
            GameService.instance.SetCurrentTurn();
            return;
        }

        GameService.instance.isPlayingMove = true;
        Debug.Log("Dice Rolling");

    }

    private bool isCurrentHouseFull()
    {
        return GameService.instance.currentTurn == GameService.Turn.blueTurn && GameService.instance.blueHouse.isHouseFull()
                    || GameService.instance.currentTurn == GameService.Turn.redTurn && GameService.instance.redHouse.isHouseFull()
                   || GameService.instance.currentTurn == GameService.Turn.greenTurn && GameService.instance.greenHouse.isHouseFull()
                   || GameService.instance.currentTurn == GameService.Turn.yellowTurn && GameService.instance.yellowHouse.isHouseFull();
    }

    private async Task<int> RollingAnimationEffect()
    {
        animator.SetBool("DiceRolling", true);
        await Task.Delay(500);

        int rand = Random.Range(0, 6);
        diceButtonImage.sprite = diceImages[rand];


        await Task.Delay(500);
        rand = Random.Range(0, 6);
        diceButtonImage.sprite = diceImages[rand];


        await Task.Delay(500);
        rand = Random.Range(0, 6);
        diceButtonImage.sprite = diceImages[rand];


        await Task.Delay(500);
        rand = Random.Range(0, 6);
        diceButtonImage.sprite = diceImages[rand];

        animator.SetBool("DiceRolling", false);
        return rand;
    }

    public int GetCurrentDiceNumber()
    {
        return currentDiceNumber;
    }
    public void UpdateDiceColor(GameService.Turn turn)
    {
        switch (turn)
        {
            case GameService.Turn.blueTurn:
                {
                    diceButtonImage.color = colors[0];
                    break;
                }
            case GameService.Turn.redTurn:
                {
                    diceButtonImage.color = colors[1];
                    break;
                }
            case GameService.Turn.greenTurn:
                {

                    diceButtonImage.color = colors[2];
                    break;
                }
            case GameService.Turn.yellowTurn:
                {
                    diceButtonImage.color = colors[3];
                    break;
                }
        }
    }
}
