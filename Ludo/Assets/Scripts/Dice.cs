using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class Dice : MonoBehaviour
{
    [SerializeField]
    private Sprite[] diceImages;
    private Image diceButtonImage;
    private Animator animator;
    private int currentDiceNumber;

    // Start is called before the first frame update
    private void Awake()
    {
        diceButtonImage = GetComponent<Image>();
        animator = GetComponent<Animator>();
        int rand = Random.Range(0, 6);
        diceButtonImage.sprite = diceImages[rand];


    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void ShuffleDice()
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

        currentDiceNumber = rand + 1;
        Debug.Log("Dice Rolling");



    }
}
