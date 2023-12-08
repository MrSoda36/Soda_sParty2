using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Store the players references
    [SerializeField] GameObject[] players = new GameObject[4];

    //Store the ShakeByInputSystem references
    [SerializeField] ShakeByInputSystem ShakeScript;


    //Store the Gamepad count
    public int GamepadCount { get; private set; } = 0;

    public event Action<int> OnGamepadConnected;
    private void Start()
    {
        GamepadCount = InputSystem.devices.OfType<Gamepad>().Count();
        //Debug.Log("GamepadCount: " + GamepadCount);
        if (GamepadCount > 0)
        {
            OnGamepadConnected?.Invoke(GamepadCount);
        }
    }

    private void FixedUpdate()
    {
        int actualGamepadCount = InputSystem.devices.OfType<Gamepad>().Count();
        if (actualGamepadCount != GamepadCount)
        {
            GamepadCount = actualGamepadCount;
            OnGamepadConnected?.Invoke(actualGamepadCount);
        }
    }

    public void FirstPlayerInput(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;

        ShakeScript.OnMashingFirstPlayer();
    }
    public void SecondPlayerInput(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;

        ShakeScript.OnMashingSecondPlayer();
    }
    public void ThirdPlayerInput(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;

        if (players[2].activeSelf)
        {
            ShakeScript.OnMashingThirdPlayer();
        }
    }
    public void FourthPlayerInput(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;

        if (players[3].activeSelf)
        {
            ShakeScript.OnMashingFourthPlayer();
        }
    }
}
