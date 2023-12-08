using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _playerPanel;
    [SerializeField] private TMP_Text _playerText;
    [SerializeField] private TMP_Text _continueText;

    [SerializeField] private TMP_Text _cocaScoreText;
    [SerializeField] private TMP_Text _pepsiScoreText;
    [SerializeField] private TMP_Text _fantaScoreText;
    [SerializeField] private TMP_Text _spriteScoreText;

    [SerializeField] private Button _winButton;
    //[SerializeField] private Button _pepsiWinButton;

    public void Initialize()
    {
        _playerPanel.SetActive(true);
        _playerText.SetText("Coca Joue");
        _playerText.color = new Color(159, 0, 0);

        _cocaScoreText.SetText("0");
        _pepsiScoreText.SetText("0");
        _fantaScoreText.SetText("0");
        _spriteScoreText.SetText("0");

        _winButton.gameObject.SetActive(false);
        //_cocaWinButton.gameObject.SetActive(false);
        //_pepsiWinButton.gameObject.SetActive(false);
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

    public void ChangePlayerScreen(int currentPlayer)
    {
        _playerPanel.SetActive(true);

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
    }

    public void HidePanel()
    {
        _playerPanel.SetActive(false);
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
        _continueText.gameObject.SetActive(false);
    }
}
