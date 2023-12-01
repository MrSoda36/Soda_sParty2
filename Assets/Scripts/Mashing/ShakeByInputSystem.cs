using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Security.Cryptography;
using System;
using Random = UnityEngine.Random;

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

    //Store the boolean to know if the player can shake their bottle
    bool CocaCanShake = true;
    bool PepsiCanShake = true;
    bool FantaCanShake = true;
    bool SpriteCanShake = true;

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

    //Store the AudioSources Component on each bottle
    AudioSource CocaAudioSource;
    AudioSource PepsiAudioSource;
    AudioSource FantaAudioSource;
    AudioSource SpriteAudioSource;


    //Set the Event to call when a player reach the win count
    public event Action<GameObject> OnWinReached;


    private void Start()
    {
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
            Debug.Log("First Player");
            CocaAudioSource.Play();
            CocaCounter++;
            Shake(CocaBottle,CocaCanShake);

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
            Debug.Log("Second Player");
            PepsiAudioSource.Play();
            PepsiCounter++;
            Shake(PepsiBottle, PepsiCanShake);
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
            Debug.Log("Third Player");
            FantaAudioSource.Play();
            FantaCounter++;
            Shake(FantaBottle, FantaCanShake);
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
            Debug.Log("Fourth Player");
            SpriteAudioSource.Play();
            SpriteCounter++;
            Shake(SpriteBottle, SpriteCanShake);
            if (SpriteCounter >= WinCount)
            {
                End = true;
                OnWinReached?.Invoke(SpriteBottle);
            }
            SpriteSlider.value = SpriteCounter;
        }
    }

    void Shake(GameObject Bottle, bool CanShake)
    {
        if (CanShake)
        {
            Bottle.transform.DOShakeScale(0.1f, 0.01f);
            Bottle.transform.DOShakeRotation(0.1f, 45);
            CanShake = false;
            StartCoroutine(WaitForReShake(CanShake));
        }
    }


    IEnumerator WaitForReShake(bool CanShake)
    {
        yield return new WaitForSeconds(0.1f);
        CanShake = true;
    }

}
