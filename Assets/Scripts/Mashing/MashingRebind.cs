using System;
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


    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    event Action OnRebind;

    private void Start()
    {
        OnRebind += DisplayStartRebind;
    }

    public void RebindKeyboard(InputActionReference _ref)
    {
        InputAction _action = _ref.action;
        OnRebind?.Invoke();
        _playerInput.gameObject.SetActive(true);
        rebindingOperation = _ref.action.PerformInteractiveRebinding(0)
            .WithControlsExcluding("Mouse")
            .WithControlsExcluding("Gamepad")
            .WithControlsExcluding("Touchpad")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(FirstPlayerKeyboard.action))
            .Start();
    }

    void RebindComplete(InputAction _action)
    {
        rebindingOperation.Dispose();
        _playerInput.gameObject.SetActive(false);
        Debug.Log(InputControlPath.ToHumanReadableString(_action.bindings[0].effectivePath,InputControlPath.HumanReadableStringOptions.OmitDevice));
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
