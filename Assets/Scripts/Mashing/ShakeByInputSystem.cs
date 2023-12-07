using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class ShakeByInputSystem : MonoBehaviour
{
    //Set if the game is finished or not
    public bool End { get; private set; } = false;

    //Store the counter of each player
    int CocaCounter = 0;
    int PepsiCounter = 0;
    int FantaCounter = 0;
    int SpriteCounter = 0;

    //Store the win count
    int WinCount;

    [Header("Bottles")]
    //Store the bottles references
    [SerializeField] GameObject CocaBottle;
    [SerializeField] GameObject PepsiBottle;
    [SerializeField] GameObject FantaBottle;
    [SerializeField] GameObject SpriteBottle;

    [Header("Sliders")]
    //Store the sliders references
    [SerializeField] UnityEngine.UI.Slider CocaSlider;
    [SerializeField] UnityEngine.UI.Slider PepsiSlider;
    [SerializeField] UnityEngine.UI.Slider FantaSlider;
    [SerializeField] UnityEngine.UI.Slider SpriteSlider;

    [Header("AudioSources")]
    //Store the AudioSources Component on each bottle
    AudioSource CocaAudioSource;
    AudioSource PepsiAudioSource;
    AudioSource FantaAudioSource;
    AudioSource SpriteAudioSource;

    [Header("GameSetUp")]
    //Store the gameSetUp reference to get the gamepad player
    [SerializeField] GameSetUp _gameSetUp;


    //Set the Event to call when a player reach the win count
    public event Action<GameObject> OnWinReached;


    private void Start()
    {
        //Stop all the Tweens
        OnWinReached += Finish;



        //Set the win count
        WinCount = Random.Range(80, 100);

        //Set the max value of the sliders
        CocaSlider.maxValue = WinCount;
        PepsiSlider.maxValue = WinCount;
        FantaSlider.maxValue = WinCount;
        SpriteSlider.maxValue = WinCount;

        //Get the AudioSources Component on each bottle
        CocaAudioSource = CocaBottle.GetComponent<AudioSource>();
        PepsiAudioSource = PepsiBottle.GetComponent<AudioSource>();
        FantaAudioSource = FantaBottle.GetComponent<AudioSource>();
        SpriteAudioSource = SpriteBottle.GetComponent<AudioSource>();

    }
    public void OnMashingFirstPlayer()
    {
        if (!End)
        {
            CocaAudioSource.Play();
            CocaCounter++;
            Shake(CocaBottle);

            if (CocaCounter >= WinCount)
            {
                End = true;
                OnWinReached?.Invoke(CocaBottle);
            }
            CocaSlider.value = CocaCounter;
        }
    }
    public void OnMashingSecondPlayer()
    {
        if (!End)
        {
            PepsiAudioSource.Play();
            PepsiCounter++;
            Shake(PepsiBottle);
            if (PepsiCounter >= WinCount)
            {
                End = true;
                OnWinReached?.Invoke(PepsiBottle);
            }
            PepsiSlider.value = PepsiCounter;
        }
    }
    public void OnMashingThirdPlayer()
    {
        if (!End)
        {
            FantaAudioSource.Play();
            FantaCounter++;
            Shake(FantaBottle);
            if (FantaCounter >= WinCount)
            {
                End = true;
                OnWinReached?.Invoke(FantaBottle);
            }
            FantaSlider.value = FantaCounter;
        }
    }
    public void OnMashingFourthPlayer()
    {
        if (!End)
        {
            SpriteAudioSource.Play();
            SpriteCounter++;
            Shake(SpriteBottle);
            if (SpriteCounter >= WinCount)
            {
                End = true;
                OnWinReached?.Invoke(SpriteBottle);
            }
            SpriteSlider.value = SpriteCounter;
        }
    }

    void Shake(GameObject Bottle)
    {
        if (Bottle.transform != null && !End)
        {
            Bottle.transform.DOShakeScale(0.1f, 0.01f);
            Bottle.transform.DOShakeRotation(0.1f, 45);
        }
    }

    private void Finish(GameObject Winner)
    {
        foreach (GameObject player in _gameSetUp._gamepadPlayers)
        {
            if (player.activeSelf == true)
            {
                player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Rebind");
            }
            else
            {
                break;
            }
        }
    }
}
