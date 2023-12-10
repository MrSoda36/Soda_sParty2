using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCardSelector : MonoBehaviour
{
    [SerializeField] private MemoryInput _input;
    [SerializeField] private MemoryBehaviour _behaviour;

    [SerializeField] private float _selectDelay = 0.4f;

    private bool _hasChosen;
    //private int _selectedIndex;
    private bool _waitingForKey = false;

    // Start is called before the first frame update
    void Start()
    {
         _input.OnKeyPressed += KeyListener;
    }


    public void StartSelection(Button[] buttonTab)
    {
        _hasChosen = false;
        _waitingForKey = true;

        StartCoroutine(CardSelection(buttonTab));

        //return _selectedIndex;
    }

    /// <summary>
    /// Goes through each non flipped card for the player to select
    /// </summary>
    /// <param name="buttonTab"></param>
    /// <returns></returns>
    private IEnumerator CardSelection(Button[] buttonTab)
    {
        int index = 0;

        while (!_hasChosen)
        {
            if (buttonTab[index].gameObject.activeSelf)
            {
                buttonTab[index].image.color = new Color(0.5f, 0.5f, 0.5f, 1f);
                //Debug.Log(buttonTab[index]);
                
                yield return new WaitForSeconds(_selectDelay);

                buttonTab[index].image.color = Color.white;
            }


            index = (index + 1) % buttonTab.Length;
        }
        

        _behaviour.FlipCard((index + buttonTab.Length - 1) % buttonTab.Length);

        yield return null;
    }

    //Called when the Key is pressed
    private void KeyListener()
    {
        if (_waitingForKey)
        {
            _hasChosen = true;
            _waitingForKey = false;
        }
    }
}
