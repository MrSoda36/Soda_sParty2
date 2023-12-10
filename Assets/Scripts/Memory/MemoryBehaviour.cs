using System.Collections;
using UnityEngine;
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
    [SerializeField] private CardData[] _datas;

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

    
    private bool _flipEnded = false;

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

    //Swaps the cards order around, then assign each card its image
    public void ShuffleCards()
    {
        int tmp;
        int index1;
        int index2;

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
            _images[i].sprite = _datas[_valueTranslator[i]].cardImage;
        }        
    }

    //The main Gameplay Loop
    public IEnumerator GamePlay()
    {

        while (!CheckWin())
        {
            _selector.StartSelection(_buttons);

            yield return new WaitUntil(() => _flipEnded);   //Waits for the turn to end
            _flipEnded = false;
        }

        //The game's end : Someone Won
        gameObject.GetComponent<AudioSource>().Play();
        _ui.VictoryScreen(_player.PlayerWinner());
        yield return null;
    }

    

    //Flips a card and record it. Calls CheckPair() when 2 cards are flipped
    public void FlipCard(int buttonValue)
    {
        _buttons[buttonValue].gameObject.SetActive(false);

        if (_buttonPressed[0] == -1)     //The player hasn't clicked on any card yet
        {
            _pressValues[0] = _valueTranslator[buttonValue];
            _buttonPressed[0] = buttonValue;
            NextFlip();
        }
        else                            //The player already clicked on a card -> Checks for a pair
        {
            _pressValues[1] = _valueTranslator[buttonValue];
            _buttonPressed[1] = buttonValue;
            CheckPair();
        }
    }

    //Compares the 2 card that have been recorded by FlipCard. Increases the current player's score if they're the same, calls FlipBack if they aren't
    private void CheckPair()
    {
        if (_pressValues[0] == _pressValues[1])
        {
            Debug.Log("Pair");

            _winNumber += 1;
            _player.IncreaseScore();
            _ui.SetScore(_player.CurrentPlayer, _player.GetCurrentPlayerScore());

            NextFlip();
        }
        else
        {
            StartCoroutine(FlipBack());                    //Flips back the cards
        }

        _buttonPressed[0] = -1;
        _buttonPressed[1] = -1;
    }

    //Flips back recorded cards after a short delay
    private IEnumerator FlipBack()
    {
        Debug.Log("FlipDelayEnter");
        int button1 = _buttonPressed[0];
        int button2 = _buttonPressed[1];

        yield return new WaitForSeconds(0.5f);

        _buttons[button1].gameObject.SetActive(true);
        _buttons[button2].gameObject.SetActive(true);


        StartCoroutine(TurnEnd());
    }

    //Ends the turn and wait for the next player  before starting the next flip 
    private IEnumerator TurnEnd()
    {
        _player.ChangePlayer();

        yield return StartCoroutine(_ui.DisplayPlayerScreen(_player.CurrentPlayer));

        NextFlip();

        yield return null;
    }


    //Starts another Flip
    private void NextFlip()
    {
        _flipEnded = true;
    }

    
    
    //Returns true if all cards have been flipped
    private bool CheckWin()
    {
        return (_winNumber == _valueTranslator.Length / 2);
    }
}