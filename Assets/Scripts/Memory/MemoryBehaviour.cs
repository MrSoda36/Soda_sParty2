using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MemoryBehaviour : MonoBehaviour
{
    //Other Scripts
    [SerializeField] private MemoryUI _ui;
    [SerializeField] private MemoryPlayers _player;
    [SerializeField] private MemoryInput _input;
    [SerializeField] private MemoryCardSelector _selector;

    //Cards and sprites
    [SerializeField] private GameObject[] _cards;
    [SerializeField] private Sprite[] _sprites;

    //List of the card's buttons and images
    private Button[] _buttons;
    private Image[] _images;

    //Represent flipped cards
    private int[] _pressValues = { -1, -1 };
    private int[] _buttonPressed = { -1, -1 };

    //The cards' hidden value (needs to be initialized because of unoptimised code)
    //Update : Code has been optimized
    private int[] _valueTranslator;
    private int _winNumber = 0;

    private bool _waitingForKey = false;
    private bool _keyPressed = false;
    private bool _flipEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        _input.OnKeyPressed += KeyListener;
    }

    //Extract all wanted infos form the list of GameObject Cards. Also instanciates the valueTranslator
    public void ExtractCardInfo()
    {
        _buttons = new Button[_cards.Length];
        _images = new Image[_cards.Length];
        _valueTranslator = new int[_cards.Length];

        int tmpIndex = 0;

        foreach (GameObject card in _cards)
        {
            _buttons[tmpIndex] = card.transform.GetChild(0).gameObject.GetComponent<Button>();     //Get the card's first child's gameObject
            _images[tmpIndex] = card.GetComponent<Image>();
            _valueTranslator[tmpIndex] = Mathf.RoundToInt(tmpIndex / 2);    //Goal : achieve a tab that looks like {0, 0, 1, 1, 2, 2, 3, 3, ...} and that is the length of the cards

            tmpIndex++;
        }

        foreach (Button button in _buttons)                    //Prevent clicking on the cards
        {
            button.GetComponent<Button>().interactable = false;
        }

        ShuffleCards();
    }


    public void ShuffleCards()
    {
        int tmp = 0;
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < 50; i++)
        {
            index1 = Random.Range(0, _valueTranslator.Length);
            index2 = Random.Range(0, _valueTranslator.Length);

            tmp = _valueTranslator[index1];
            _valueTranslator[index1] = _valueTranslator[index2];
            _valueTranslator[index2] = tmp;
        }

        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].sprite = _sprites[_valueTranslator[i]];
        }        
    }

    //The main Gameplay Loop
    public IEnumerator GamePlay()
    {

        while (!CheckWin())
        {
            //Debug.Log("FlipCard");
            _selector.StartSelection(_buttons);

            yield return new WaitUntil(() => _flipEnded);
            _flipEnded = false;
        }

        _ui.VictoryScreen(_player.PlayerWinner());
        yield return null;
    }


    public void FlipCard(int buttonValue)
    {
        _buttons[buttonValue].gameObject.SetActive(false);

        if (_buttonPressed[0] == -1)     //The player hasn't clicked on any card yet
        {
            _pressValues[0] = _valueTranslator[buttonValue];
            _buttonPressed[0] = buttonValue;
            NextTurn();
        }
        else                            //The player already clicked on a card -> Checks for a pair
        {
            _pressValues[1] = _valueTranslator[buttonValue];
            _buttonPressed[1] = buttonValue;
            CheckPair();
        }
    }

    public void CheckPair()
    {
        if (_pressValues[0] == _pressValues[1])
        {
            Debug.Log("Pair");

            _winNumber += 1;
            _player.IncreaseScore();
            _ui.SetScore(_player.CurrentPlayer, _player.GetCurrentPlayerScore());

            NextTurn();
        }
        else
        {
            StartCoroutine(FlipDelay());                    //Flips back the cards
        }

        _buttonPressed[0] = -1;
        _buttonPressed[1] = -1;
    }

    public IEnumerator FlipDelay()
    {
        Debug.Log("FlipDelayEnter");
        int button1 = _buttonPressed[0];
        int button2 = _buttonPressed[1];

        /*
        foreach (Button button in _buttons)                    //Prevent clicking more cards while the previous 2 are flipping back
        {
            button.GetComponent<Button>().interactable = false;
        }
        */

        yield return new WaitForSeconds((float)0.5);

        _buttons[button1].gameObject.SetActive(true);
        _buttons[button2].gameObject.SetActive(true);

        /*
        foreach (Button button in _buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }
        */

        //Debug.Log("FlipDelayEnd");
        StartCoroutine(TurnEnd());
    }

    private IEnumerator TurnEnd()
    {
        //Debug.Log("TurnEndEnter");
        _player.ChangePlayer();

        _ui.ChangePlayerScreen(_player.CurrentPlayer);
        yield return StartCoroutine(WaitForInput());
        _ui.HidePanel();

        NextTurn();
        //Debug.Log("TurnEndEnd");
        yield return null;
    }

    private void NextTurn()
    {
        _flipEnded = true;
    }

    
    private IEnumerator WaitForInput()
    {
        _waitingForKey = true;

        yield return new WaitUntil(() => _keyPressed) ;

        _keyPressed = false;
        _waitingForKey = false;
    }

    private void KeyListener()
    {
        if (_waitingForKey)
        {
            _keyPressed = true;
        }
    }
    

    private bool CheckWin()
    {
        return (_winNumber == _valueTranslator.Length / 2);
    }
}