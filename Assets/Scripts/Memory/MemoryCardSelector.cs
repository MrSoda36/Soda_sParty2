using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCardSelector : MonoBehaviour
{
    public bool HasChosen { get; private set; }

    [SerializeField] private MemoryInput _input;
    [SerializeField] private MemoryBehaviour _behaviour;

    private int _selectedIndex;
    private bool _waitingForKey = false;

    // Start is called before the first frame update
    void Start()
    {
         _input.OnKeyPressed += KeyListener;
    }


    public int StartSelection(Button[] buttonTab)
    {
        HasChosen = false;
        _waitingForKey = true;

        StartCoroutine(CardSelection(buttonTab));

        return _selectedIndex;
    }

    //Goes through each non flipped card for the player to select
    private IEnumerator CardSelection(Button[] buttonTab)
    {
        int index = 0;

        while (!HasChosen)
        {
            if (buttonTab[index].gameObject.activeSelf)
            {
                buttonTab[index].image.color = new Color(0.5f, 0.5f, 0.5f, 1f);
                //Debug.Log(buttonTab[index]);
                
                yield return new WaitForSeconds(0.25f);

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
            HasChosen = true;
            _waitingForKey = false;
        }
    }
}
