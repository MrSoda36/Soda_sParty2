using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MemoryBehaviour : MonoBehaviour
{
    public GameObject[] buttons;
    public Image[] images;
    public Sprite[] sprites;

    public GameObject playerPanel;
    public TMP_Text playerText;
    public TMP_Text continueText;

    public TMP_Text cocaScoreText;
    public TMP_Text pepsiScoreText;

    public Button cocaWinButton;
    public Button pepsiWinButton;

    private int[] pressValues = { -1, -1 };
    private int[] buttonPressed = { -1, -1 };

    //Uses the buttonValue given by the order of the button to find its hidden value (needs to be initialized because of unoptomised code)
    private int[] valueTranslator = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
    private int winNumber = 0;

    private int currentPlayer = 1;
    private int[] playerScore = { 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitText());
    }


    private IEnumerator InitText()
    {
        playerPanel.SetActive(true);   
        playerText.SetText("Coca Joue");
        playerText.color = new Color(159, 0, 0);

        continueText.color = new Color(159, 0, 0);

        cocaScoreText.SetText("0");
        pepsiScoreText.SetText("0");

        cocaWinButton.gameObject.SetActive(false);
        pepsiWinButton.gameObject.SetActive(false);

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        GameStart();
        playerPanel.SetActive(false);

        yield return null;
    }

    public void GameStart()
    {
        ShuffleCards();

        for (int i = 0; i < buttons.Length; i++)
        {
            images[i].sprite = sprites[valueTranslator[i]];
        }
    }

    private void ShuffleCards()
    {
        int tmp = 0;
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < 50; i++)
        {
            index1 = Random.Range(0, valueTranslator.Length);
            index2 = Random.Range(0, valueTranslator.Length);

            tmp = valueTranslator[index1];
            valueTranslator[index1] = valueTranslator[index2];
            valueTranslator[index2] = tmp;
        }
    }

    public void ButtonClick(int buttonValue)
    {
        buttons[buttonValue].gameObject.SetActive(false);
        //Debug.Log(buttonValue);

        if (buttonPressed[0] == -1)     //The player hasn't clicked on any card
        {
            pressValues[0] = valueTranslator[buttonValue];
            buttonPressed[0] = buttonValue;
        }
        else                            //The player clicked on a card -> Checks for a pair
        {
            pressValues[1] = valueTranslator[buttonValue];
            buttonPressed[1] = buttonValue;
            CheckPair();
        }
    }

    public void CheckPair()
    {
        if (pressValues[0] == pressValues[1])
        {
            Debug.Log("Pair");

            winNumber += 1;
            playerScore[currentPlayer - 1] += 1;

            if (currentPlayer == 1)
            {
                cocaScoreText.SetText((playerScore[currentPlayer - 1]).ToString());
            }
            else
            {
                pepsiScoreText.SetText((playerScore[currentPlayer - 1]).ToString());
            }

            if (winNumber == valueTranslator.Length / 2)    //6 pairs to win
            {
                //SceneManager.LoadScene("Menu");
                PlayerWinner();
            }
        }
        else
        {
            //Debug.Log("NotPair");
            StartCoroutine(FlipDelay());
        }

        buttonPressed[0] = -1;
        buttonPressed[1] = -1;
    }

    public IEnumerator FlipDelay()
    {
        int button1 = buttonPressed[0];
        int button2 = buttonPressed[1];

        foreach (GameObject button in buttons)
        {
            button.GetComponent<Button>().interactable = false;
        }

        yield return new WaitForSeconds((float)0.5);

        buttons[button1].gameObject.SetActive(true);
        buttons[button2].gameObject.SetActive(true);

        foreach (GameObject button in buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }

        StartCoroutine(ChangePlayer());
    }

    private IEnumerator ChangePlayer()
    {
        playerPanel.SetActive(true);

        if (currentPlayer == 1)
        {
            this.currentPlayer = 2;

            playerText.SetText("Pepsi joue");
            playerText.color = new Color(0, 0, 159);

            continueText.color = new Color(0, 0, 159);
        }
        else
        {
            this.currentPlayer = 1;

            playerText.SetText("Coca joue");
            playerText.color = new Color(159, 0, 0);

            continueText.color = new Color(159, 0, 0);
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        playerPanel.SetActive(false);

        yield return null;
    }

    private void PlayerWinner()
    {
        playerPanel.SetActive(true);
        continueText.gameObject.SetActive(false);

        if (playerScore[0] > playerScore[1])
        {
            Debug.Log("Coca à gagné");

            playerText.SetText("Coca à gagné !");
            playerText.color = new Color(159, 0, 0);

            cocaWinButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Pepsi à gagné");

            playerText.SetText("Pepsi à gagné !");
            playerText.color = new Color(0, 0, 159);

            pepsiWinButton.gameObject.SetActive(true);
        }
        //Il y a un nombre impair de paires, empêchant une égalité
    }
}