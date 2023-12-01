using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Security.Cryptography;
using System;
using Random = UnityEngine.Random;

public class ShakeByInputSystem : MonoBehaviour
{
    //Set if the game is finished or not
    bool End = false;

    //Store the counter of each player
    int CocaCounter = 0;
    int PepsiCounter = 0;
    int FantaCounter = 0;
    int SpriteCounter = 0;

    //Store the win count
    int WinCount;

    //Store the boolean to know if the player can shake
    bool CanShake = true;

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
    }
    public void OnMashingFirstPlayer()
    {
        Debug.Log("First Player");
        if (!End)
        {
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
        Debug.Log("Second Player");
        if (!End)
        {
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
        Debug.Log("Third Player");
        if (!End)
        {
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
        Debug.Log("Fourth Player");
        if (!End)
        {
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
        if (CanShake)
        {
            Bottle.transform.DOShakeScale(0.1f, 0.01f);
            Bottle.transform.DOShakeRotation(0.1f, 45);
            CanShake = false;
            StartCoroutine(WaitForReShake());
        }
    }


    IEnumerator WaitForReShake()
    {
        yield return new WaitForSeconds(0.1f);
        CanShake = true;
    }

}
