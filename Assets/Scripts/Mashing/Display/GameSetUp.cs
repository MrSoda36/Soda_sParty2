using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameSetUp : MonoBehaviour
{
    //Store the number of players reference
    [SerializeField] NumberOfPlayer _playerNb;

    //Store the bottles references
    [SerializeField] List<GameObject> _bottles;

    //Store the cameras references
    [SerializeField] List<Camera> _cameras;
    [SerializeField] Camera _UiCamera;
    [SerializeField] Camera _NullCam;

    //Store the players references
    [SerializeField] List<GameObject> _players;
    [SerializeField] public List<GameObject> _gamepadPlayers;

    //Store the player input reference
    [SerializeField] GameObject _playerInputs;

    //Store the input manager reference
    [SerializeField] InputManager _inputManager;

    private void Awake()
    {
        _playerNb.OnNumberOfPlayersChanged += DisplayBottle;
        _playerNb.OnNumberOfPlayersChanged += DisplayCamera;

        _playerNb.OnNumberOfPlayersChanged += ActivatePlayers;
        _playerNb.OnNumberOfPlayersChanged += SwitchActionGamepadMap;

        _inputManager.OnGamepadConnected += ActivateGamepadPlayer;
    }

    void DisplayBottle(int NbPlayer)
    {
        for (int i = 0; i < NbPlayer; i++)
        {
            _bottles[i].SetActive(true);
        }
    }
    void DisplayCamera(int NbPlayer)
    {
        _UiCamera.gameObject.SetActive(false);

        if (NbPlayer == 2)
        {
            Camera FirstCamera = _cameras[0];
            Camera SecondCamera = _cameras[1];
            FirstCamera.gameObject.SetActive(true);
            SecondCamera.gameObject.SetActive(true);
            FirstCamera.rect = new Rect(0, 0, 0.5f, 1);
            SecondCamera.rect = new Rect(0.5f, 0, 0.5f, 1);
        }
        else
        {
            if (NbPlayer == 3)
            {
                _NullCam.gameObject.SetActive(true);
            }
            for (int i = 0; i < NbPlayer; i++)
            {
                _cameras[i].gameObject.SetActive(true);

            }
        }
    }

    void ActivatePlayers(int NbPlayer)
    {
        _playerInputs.SetActive(true);
        for (int i = 0; i < NbPlayer; i++)
        {
            _players[i].SetActive(true);
        }
    }

    void ActivateGamepadPlayer(int NbGamepad)
    {
        switch (NbGamepad)
        {
            case 0:
                _gamepadPlayers[0].SetActive(false);
                _gamepadPlayers[1].SetActive(false);
                _gamepadPlayers[2].SetActive(false);
                _gamepadPlayers[3].SetActive(false);
                break;
            case 1:
                _gamepadPlayers[0].SetActive(true);
                _gamepadPlayers[1].SetActive(false);
                _gamepadPlayers[2].SetActive(false);
                _gamepadPlayers[3].SetActive(false);
                break;
            case 2:
                _gamepadPlayers[0].SetActive(true);
                _gamepadPlayers[1].SetActive(true);
                _gamepadPlayers[2].SetActive(false);
                _gamepadPlayers[3].SetActive(false);
                break;
            case 3:
                _gamepadPlayers[0].SetActive(true);
                _gamepadPlayers[1].SetActive(true);
                _gamepadPlayers[2].SetActive(true);
                _gamepadPlayers[3].SetActive(false);
                break;
            case 4:
                _gamepadPlayers[0].SetActive(true);
                _gamepadPlayers[1].SetActive(true);
                _gamepadPlayers[2].SetActive(true);
                _gamepadPlayers[3].SetActive(true);
                break;
        }
    }

    void SwitchActionGamepadMap(int NbPlayer)
    {
        switch (_inputManager.GamepadCount)
        {
            case 1:
                _gamepadPlayers[0].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerOneGamepad");
                break;
            case 2:
                _gamepadPlayers[0].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerOneGamepad");
                _gamepadPlayers[1].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerTwoGamepad");
                break;
            case 3:
                _gamepadPlayers[0].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerOneGamepad");
                _gamepadPlayers[1].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerTwoGamepad");
                _gamepadPlayers[2].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerThreeGamepad");
                break;
            case 4:
                _gamepadPlayers[0].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerOneGamepad");
                _gamepadPlayers[1].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerTwoGamepad");
                _gamepadPlayers[2].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerThreeGamepad");
                _gamepadPlayers[3].GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerFourGamepad");
                break;
            default:
                break;
        }
    }
}
