using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite;

    [SerializeField]
    private Image playerChoice_Img, opponentChoice_Img;

    [SerializeField]
    private Text infoText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationController animationController;

    void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    public void SetChoices(GameChoices gameChoices)
    {
        switch (gameChoices)
        {
            case GameChoices.ROCK:

                playerChoice_Img.sprite = rock_Sprite;
                player_Choice = GameChoices.ROCK;
                break;

            case GameChoices.PAPER:

                playerChoice_Img.sprite = paper_Sprite;
                player_Choice = GameChoices.PAPER;
                break;

            case GameChoices.SCISSORS:

                playerChoice_Img.sprite = scissors_Sprite;
                player_Choice = GameChoices.SCISSORS;
                break;
        }
        SetOpponentChoice();
        DetermineWinner();

    }

    void SetOpponentChoice()
    {
        int rnd = Random.Range(0, 3);

        switch (rnd)
        {
            case 0:
                opponent_Choice = GameChoices.ROCK;
                opponentChoice_Img.sprite = rock_Sprite;
                break;

            case 1:
                opponent_Choice = GameChoices.PAPER;
                opponentChoice_Img.sprite = paper_Sprite;
                break;

            case 2:
                opponent_Choice = GameChoices.SCISSORS;
                opponentChoice_Img.sprite = scissors_Sprite;
                break;
        }
    }

    void DetermineWinner()
    {
        //DRAW MATCH
        if (player_Choice == opponent_Choice)
        {
            //Draw
            infoText.text = "It's a Draw!";
            StartCoroutine(DisplayWinnersAndRestart());

            return;
        }

        //YOU WIN
        if (player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK)
        {
            //you won
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnersAndRestart());
            return;
        }
        if (player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER)
        {
            //you won
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnersAndRestart());
            return;
        }
        if (player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS)
        {
            //you won
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnersAndRestart());
            return;
        }

        //OPPONENT WINS 
        if (opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK)
        {
            //you Lost
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnersAndRestart());
            return;
        }
        if (opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER)
        {
            //you lost
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnersAndRestart());
            return;
        }
        if (opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS)
        {
            //you lost
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnersAndRestart());
            return;
        }



    }

    IEnumerator DisplayWinnersAndRestart()
    {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();
    }

    
}
