using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.Windows;

public class MemoryUI : MonoBehaviour
{
    [SerializeField] private MemoryInput _input;

    [Header("Panels")]
    [SerializeField] private GameObject _playerPanel;
    [SerializeField] private GameObject _initPanel;

    [Header("Texts")]
    [SerializeField] private TMP_Text _playerText;

    [SerializeField] private TMP_Text _cocaScoreText;
    [SerializeField] private TMP_Text _pepsiScoreText;
    [SerializeField] private TMP_Text _fantaScoreText;
    [SerializeField] private TMP_Text _spriteScoreText;

    [Header("Button")]
    [SerializeField] private Button _winButton;

    private bool _waitingForKey = false;
    private bool _keyPressed = false;

    private void Start()
    {
        _input.OnKeyPressed += KeyListener;
    }

    //Sets and hides the text and panels
    public void Initialize(int playerNumber)
    {
        _playerText.SetText("Coca Joue");
        _playerText.color = new Color(159, 0, 0);

        _winButton.gameObject.SetActive(false);

        _cocaScoreText.SetText("0");
        _pepsiScoreText.SetText("0");
        _fantaScoreText.SetText("0");
        _spriteScoreText.SetText("0");

        if (playerNumber < 3)
        {
            _fantaScoreText.gameObject.SetActive(false);
        }
        if (playerNumber < 4)
        {
            _spriteScoreText.gameObject.SetActive(false);
        }
        
    }

    public void ShowPlayerPanel()
    {
        _playerPanel.SetActive(true);
    }

    public void HidePlayerPanel()
    {
        _playerPanel.SetActive(false);
    }

    public void ShowInitPanel()
    {
        _initPanel.SetActive(true);
    }

    public void HideInitPanel()
    {
        _initPanel.SetActive(false);
    }

    public void SetScore(int currentPlayer, int newScore)
    {
        switch (currentPlayer)
        {
            case 0:
                _cocaScoreText.SetText(newScore.ToString());
                break;

            case 1:
                _pepsiScoreText.SetText(newScore.ToString());
                break;

            case 2:
                _fantaScoreText.SetText(newScore.ToString());
                break;

            case 3:
                _spriteScoreText.SetText(newScore.ToString());
                break;
        }
    }

    public IEnumerator DisplayPlayerScreen(int currentPlayer)
    {
        ChangePlayerScreen(currentPlayer);
        yield return StartCoroutine(WaitForInput());
        HidePlayerPanel();

        yield return null;
    }

    public void ChangePlayerScreen(int currentPlayer)
    {

        switch (currentPlayer)
        {
            case 0:
                _playerText.SetText("Coca joue");
                _playerText.color = new Color(159, 0, 0);

                break;

            case 1:

                _playerText.SetText("Pepsi joue");
                _playerText.color = new Color(0, 0, 159);

                break;

            case 2:

                _playerText.SetText("Fanta joue");
                _playerText.color = new Color(159, 159, 0);

                break;

            case 3:

                _playerText.SetText("Sprite joue");
                _playerText.color = new Color(0, 159, 0);

                break;
        }


        ShowPlayerPanel();
    }

     
    public void VictoryScreen(int[] winners)
    {
        string winMessage = "";
        bool oneWinner = true;

        for (int i = 0; i < winners.Length; i++)
        {
            if (winners[i] >= 0)
            {
                if (i > 0)
                {
                    winMessage += ", ";
                    oneWinner = false;
                }

                switch (winners[i])
                {
                    case 0:
                        winMessage += "Coca";
                        break;

                    case 1:
                        winMessage += "Pepsi";
                        break;

                    case 2:
                        winMessage += "Fanta";
                        break;

                    case 3:
                        winMessage += "Sprite";
                        break;
                }
            }
        }

        if (oneWinner)
        {
            winMessage += " wins !";
        }
        else
        {
            winMessage += " win !";
        }

        _playerText.SetText(winMessage);
        _playerText.color = new Color(40, 40, 40);

        _playerPanel.SetActive(true);
        _winButton.gameObject.SetActive(true);
    }

    //Waits until the Key is pressed when called
    private IEnumerator WaitForInput()
    {
        _waitingForKey = true;

        yield return new WaitUntil(() => _keyPressed);

        _keyPressed = false;
        _waitingForKey = false;
    }

    //Called when the Key is pressed
    private void KeyListener()
    {
        if (_waitingForKey)
        {
            _keyPressed = true;
        }
    }
}
