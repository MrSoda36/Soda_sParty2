using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class Shake : MonoBehaviour
{
    [SerializeField] GameObject CocaBottle;
    [SerializeField] GameObject PepsiBottle;

    public int CocaCounter = 0;
    public int PepsiCounter = 0;
    int WinCount;

    bool CanShake = true;
    bool Muted = false;

    public GameObject SoundImage;
    public GameObject MutedImage;

    [SerializeField] Animator StartingCanvasAnimator;
    bool InstructionStillThere = true;

    public Slider CocaSlider;
    public Slider PepsiSlider;

    public GameObject FinishText;
    public GameObject CocaWinText;
    public GameObject PepsiWinText;
    bool End = false;
    public Button CocaEndButton;
    public Button PepsiEndButton;
    public Button CocaRestart;
    public Button PepsiRestart;

    private void Start()
    {
        WinCount = Random.Range(70, 90);
        CocaSlider.maxValue = WinCount;
        PepsiSlider.maxValue = WinCount;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !End)
        {
            if (InstructionStillThere)
            {
                StartingCanvasAnimator.SetBool("InstructionsDispawn", true);
                InstructionStillThere = false;
            }
            CocaCounter++;
            if (CanShake)
            {
                CocaBottle.transform.DOShakeScale(0.1f, 0.01f);
                CocaBottle.transform.DOShakeRotation(0.1f, 45);
                CanShake = false;
                StartCoroutine(WaitForReShake());
            }
            CocaBottle.GetComponent<AudioSource>().Play();
            CocaSlider.value = CocaCounter;
        }
        if (Input.GetKeyDown(KeyCode.Return) && !End)
        {
            if (InstructionStillThere)
            {
                StartingCanvasAnimator.SetBool("InstructionsDispawn", true);
                InstructionStillThere = false;
            }
            PepsiCounter++;
            if (CanShake)
            {
                PepsiBottle.transform.DOShakeScale(0.1f, 0.01f);
                PepsiBottle.transform.DOShakeRotation(0.1f, 45);
                CanShake = false;
                StartCoroutine(WaitForReShake());
            }
            PepsiBottle.GetComponent<AudioSource>().Play();
            PepsiSlider.value = PepsiCounter;
        }
        if (Input.GetKeyDown(KeyCode.J) && (CocaCounter < WinCount || PepsiCounter < WinCount))
        {
            if (Muted)
            {
                Muted = !Muted;
                CocaBottle.GetComponent<AudioSource>().volume = Convert.ToSingle(Muted); //Convertis le bool muted en float
                PepsiBottle.GetComponent<AudioSource>().volume = Convert.ToSingle(Muted); //Convertis le bool muted en float
                FinishText.GetComponent<AudioSource>().volume = Convert.ToSingle(Muted); //Convertis le bool muted en float
                SoundImage.gameObject.SetActive(false);
                MutedImage.gameObject.SetActive(true);
            }
            else
            {
                Muted = !Muted;
                CocaBottle.GetComponent<AudioSource>().volume = Convert.ToSingle(Muted); //Convertis le bool muted en float
                PepsiBottle.GetComponent<AudioSource>().volume = Convert.ToSingle(Muted); //Convertis le bool muted en float
                FinishText.GetComponent<AudioSource>().volume = Convert.ToSingle(Muted); //Convertis le bool muted en float
                MutedImage.gameObject.SetActive(false);
                SoundImage.gameObject.SetActive(true);
            }
        }
        if (CocaCounter == WinCount && !End)
        {
            End = true;
            PepsiSlider.gameObject.SetActive(false);
            FinishText.SetActive(true);
            FinishText.GetComponent<AudioSource>().Play();
            CocaWinText.SetActive(true);
            CocaEndButton.gameObject.SetActive(true);
            CocaRestart.gameObject.SetActive(true);
        }
        if (PepsiCounter == WinCount && !End)
        {
            End = true;
            CocaSlider.gameObject.SetActive(false);
            FinishText.SetActive(true);
            FinishText.GetComponent<AudioSource>().Play();
            PepsiWinText.SetActive(true);
            PepsiEndButton.gameObject.SetActive(true);
            PepsiRestart.gameObject.SetActive(true);
        }
    }

    IEnumerator WaitForReShake()
    {
        yield return new WaitForSeconds(0.1f);
        CanShake = true;
    }
}
