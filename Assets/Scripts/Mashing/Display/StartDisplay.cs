using System.Collections.Generic;
using UnityEngine;

public class StartDisplay : MonoBehaviour
{
    //Store the number of players reference
    [SerializeField] NumberOfPlayer _playerNb;

    //Store the bottles references
    [SerializeField] List<GameObject> _bottles;

    //Store the cameras references
    [SerializeField] List<Camera> _cameras;
    [SerializeField] Camera _UiCamera;
    [SerializeField] Camera _NullCam;


    private void Start()
    {
        _playerNb.OnNumberOfPlayersChanged += DisplayBottle;
        _playerNb.OnNumberOfPlayersChanged += DisplayCamera;
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
            if (NbPlayer==3)
            {
                _NullCam.gameObject.SetActive(true);
            }
            for (int i = 0; i < NbPlayer; i++)
            {
                _cameras[i].gameObject.SetActive(true);

            }
        }
    }

    void UpdateUI(int NbPlayer)
    {
        if (NbPlayer==2)
        {

        }
    }
}
