using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Store the players references
    [SerializeField] GameObject[] players = new GameObject[4];

    //Store the ShakeByInputSystem references
    [SerializeField] ShakeByInputSystem ShakeScript;


    public Gamepad[] gamepadCount;
    private void Start()
    {
        gamepadCount = InputSystem.devices.OfType<Gamepad>().ToArray();
        foreach (var item in gamepadCount)
        {
            Debug.Log(item.name);

        }
    }
    public void FirstPlayerInput()
    {
        ShakeScript.OnMashingFirstPlayer();
    }
    public void SecondPlayerInput()
    {
        ShakeScript.OnMashingSecondPlayer();
    }
    public void ThirdPlayerInput()
    {
        if (players[2].activeSelf)
        {
            ShakeScript.OnMashingThirdPlayer();
        }
    }
    public void FourthPlayerInput()
    {
        if (players[3].activeSelf)
        {
            ShakeScript.OnMashingFourthPlayer();
        }
    }
}
