using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MashingRebind : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput = null;


    [SerializeField] private GameObject UIRebind; //The UI that will be displayed when the player will rebind his keys
    [Header("Input Reference")]
    public InputActionReference FirstPlayerKeyboard = null;
    public InputActionReference SecondPlayerKeyboard = null;
    public InputActionReference ThirdPlayerKeyboard = null;
    public InputActionReference FourthPlayerKeyboard = null;



    event Action OnRebind;

    private void Start()
    {
        OnRebind += DisplayStartRebind;
    }

    public void FirstPlayerRebind()
    {
        OnRebind?.Invoke();
        _playerInput.gameObject.SetActive(true);
        FirstPlayerKeyboard.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .WithControlsExcluding("Gamepad")
            .WithControlsExcluding("Touchpad")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(FirstPlayerKeyboard))
            .Start();
    }

    void RebindComplete(InputActionReference _ref)
    {
        _playerInput.SwitchCurrentActionMap("PlayerKeyboard");
        _playerInput.gameObject.SetActive(false);
        Debug.Log(InputControlPath.ToHumanReadableString(_ref.action.bindings[0].effectivePath,InputControlPath.HumanReadableStringOptions.OmitDevice));
        UIRebind.SetActive(false);
    }

    void DisplayStartRebind()
    {
        if(UIRebind.activeSelf) 
        {
            UIRebind.SetActive(false);
        }
        else
        {
            UIRebind.SetActive(true);
        }
    }
}
