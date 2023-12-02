using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

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

    [Header("Binding Text")]
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] TMP_Text CocaBindingText;
    [SerializeField] TMP_Text PepsiBindingText;
    [SerializeField] TMP_Text FantaBindingText;
    [SerializeField] TMP_Text SpriteBindingText;


    private void Start()
    {
        _playerNb.OnNumberOfPlayersChanged += DisplayUI;
        _playerNb.OnNumberOfPlayersChanged += DisplayBindingText;
    }

    void DisplayUI(int NbPlayer)
    {
        UiParentForNumberOfPlayer.SetActive(false);
        if (NbPlayer == 2)
        {
            UiTwoPlayer.SetActive(true);
            CocaBindingText.rectTransform.position = new Vector3(CocaBindingText.rectTransform.position.x, CocaBindingText.rectTransform.position.y+10, CocaBindingText.rectTransform.position.z);
            PepsiBindingText.rectTransform.position = new Vector3(PepsiBindingText.rectTransform.position.x, PepsiBindingText.rectTransform.position.y + 10, PepsiBindingText.rectTransform.position.z);
        }
        else
        {
            UiSeparatePlayer.SetActive(true);
        }
    }

    void DisplayBindingText(int i)
    {
        CocaBindingText.text = "Press : " + _playerInput.actions["FirstPlayer"].bindings[0].effectivePath[_playerInput.actions["FirstPlayer"].bindings[0].effectivePath.Length - 1] +
            " or " +
            _playerInput.actions["FirstPlayer"].bindings[1].effectivePath;

        PepsiBindingText.text = "Press : " + _playerInput.actions["SecondPlayer"].bindings[0].effectivePath[_playerInput.actions["SecondPlayer"].bindings[0].effectivePath.Length - 1] +
            " or " + _playerInput.actions["SecondPlayer"].bindings[1].effectivePath;
        
        FantaBindingText.text = "Press : " + _playerInput.actions["ThirdPlayer"].bindings[0].effectivePath[_playerInput.actions["ThirdPlayer"].bindings[0].effectivePath.Length - 1] +
            " or " + _playerInput.actions["ThirdPlayer"].bindings[1].effectivePath;
        
        SpriteBindingText.text = "Press : " + _playerInput.actions["FourthPlayer"].bindings[0].effectivePath[_playerInput.actions["FourthPlayer"].bindings[0].effectivePath.Length - 1] +
            " or " + _playerInput.actions["FourthPlayer"].bindings[1].effectivePath;
    }
}
