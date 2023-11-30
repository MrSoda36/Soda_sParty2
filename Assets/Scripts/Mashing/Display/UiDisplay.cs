using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDisplay : MonoBehaviour
{
    //Store the number of players reference
    [Header("Player References")]
    [SerializeField] NumberOfPlayer _playerNb;

    //Store the UI references
    [Header("UI References")]
    [SerializeField] GameObject UiParentForNumberOfPlayer;
    [SerializeField] GameObject UiTwoPlayer;
    [SerializeField] GameObject UiSeparatePlayer;

    private void Start()
    {
        _playerNb.OnNumberOfPlayersChanged += DisplayUI;
    }

    void DisplayUI(int NbPlayer)
    {
        UiParentForNumberOfPlayer.SetActive(false);
        if (NbPlayer == 2)
        {
            UiTwoPlayer.SetActive(true);
        }
        else
        {
            UiSeparatePlayer.SetActive(true);
        }
    }
}
