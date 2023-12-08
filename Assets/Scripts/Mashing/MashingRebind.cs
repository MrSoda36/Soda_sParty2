using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MashingRebind : MonoBehaviour
{


    [SerializeField] private GameObject UIRebind; //The UI that will be displayed when the player will rebind his keys


    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    [Header("Gamepad Button")]
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GameObject[] _gamepadButton = new GameObject[4];


    event Action OnRebind;

    private void Start()
    {
        OnRebind += DisplayStartRebind;
        _inputManager.OnGamepadConnected += UpdateGamepadRebindUI;
    }

    public void RebindKeyboard(InputActionReference _ref)
    {
        InputAction _action = _ref.action;
        OnRebind?.Invoke();
        _action.Disable();
        rebindingOperation = _ref.action.PerformInteractiveRebinding(0)
            .WithControlsExcluding("Mouse")
            .WithControlsExcluding("Gamepad")
            .WithControlsExcluding("Touchpad")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(_action))
            .Start();
    }

    public void RebindGamepad(InputActionReference _ref)
    {
        InputAction _action = _ref.action;
        Debug.Log(_ref);
        OnRebind?.Invoke();
        _action.Disable();
        rebindingOperation = _ref.action.PerformInteractiveRebinding(0)
            .WithControlsExcluding("Mouse")
            .WithControlsExcluding("Keyboard")
            .WithControlsExcluding("LeftStick")
            .WithControlsExcluding("RightStick")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(_action))
            .Start();
    }


    void RebindComplete(InputAction _action)
    {
        InputBinding _binding = _action.bindings[0];
        _binding.overridePath = rebindingOperation.action.bindings[0].effectivePath;
        _action.ApplyBindingOverride(0, _binding);

        Debug.Log(rebindingOperation.action.bindings[0].effectivePath);
        _action.Enable();
        rebindingOperation.Dispose();
        Debug.Log(InputControlPath.ToHumanReadableString(_action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice));
        UIRebind.SetActive(false);
    }

    void DisplayStartRebind()
    {
        if (UIRebind.activeSelf)
        {
            UIRebind.SetActive(false);
        }
        else
        {
            UIRebind.SetActive(true);
        }
    }

    public void UpdateGamepadRebindUI(int _gamepadCount)
    {
        if (0 < _gamepadCount && _gamepadCount < 4)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (i <= _gamepadCount)
                {
                    _gamepadButton[i - 1].SetActive(true);
                }
                else
                {
                    _gamepadButton[i - 1].SetActive(false);
                }

            }
        }
        else if (_gamepadCount >= 4)
        {
            for (int i = 0; i < 4; i++)
            {
                _gamepadButton[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _gamepadButton.Length; i++)
            {
                _gamepadButton[i].SetActive(false);
            }
        }
    }
}
