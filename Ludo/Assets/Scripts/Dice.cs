using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class Dice : MonoBehaviour
{

    public static Dice instance;
    [SerializeField] private Sprite[] diceImages;
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
        int rand = Random.Range(0, 6);
        diceButtonImage.sprite = diceImages[rand];
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

        if (GameService.instance.currentTurn == GameService.Turn.None)
        {
            GameService.instance.SetCurrentTurn(GameService.Turn.blueTurn); //TODO(Randmize This)
        }
        GameService.instance.isPlayingMove = true;
        Debug.Log("Dice Rolling");

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
}
