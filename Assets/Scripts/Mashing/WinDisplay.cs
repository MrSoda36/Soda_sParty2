using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class WinDisplay : MonoBehaviour
{
    //Store the win canvas component
    [SerializeField] Canvas winCanvas;
    [SerializeField] Image winImage;
    [SerializeField] Image ResetButtonImage;
    [SerializeField] Image BackToMenuButtonImage;
    [SerializeField] TMP_Text winText;

    //Store the shake script to know when the game is _finished
    [SerializeField] ShakeByInputSystem ShakeScript;

    //Store the background image for the win text
    [SerializeField] Sprite CocaBackgroundImage;
    [SerializeField] Sprite PepsiBackgroundImage;
    [SerializeField] Sprite FantaBackgroundImage;
    [SerializeField] Sprite SpriteBackgroundImage;


    private void Start()
    {
        ShakeScript.OnWinReached += StartWait;
    }

    void DisplayWin(GameObject _victoriousBottle)
    {
        if (_victoriousBottle.name == "Coca")
        {
            winCanvas.gameObject.SetActive(true);
            winImage.sprite = CocaBackgroundImage;
            ResetButtonImage.sprite = CocaBackgroundImage;
            BackToMenuButtonImage.sprite = CocaBackgroundImage;
            winText.text = "Coca Wins !";
        }
        else if (_victoriousBottle.name == "Pepsi")
        {
            winCanvas.gameObject.SetActive(true);
            winImage.sprite = PepsiBackgroundImage;
            ResetButtonImage.sprite = PepsiBackgroundImage;
            BackToMenuButtonImage.sprite = PepsiBackgroundImage;
            winText.text = "Pepsi Wins !";
        }
        else if (_victoriousBottle.name == "Fanta")
        {
            winCanvas.gameObject.SetActive(true);
            winImage.sprite = FantaBackgroundImage;
            ResetButtonImage.sprite = FantaBackgroundImage;
            BackToMenuButtonImage.sprite = FantaBackgroundImage;
            winText.text = "Fanta Wins !";
        }
        else if (_victoriousBottle.name == "Sprite")
        {
            winCanvas.gameObject.SetActive(true);
            winImage.sprite = SpriteBackgroundImage;
            ResetButtonImage.sprite = SpriteBackgroundImage;
            BackToMenuButtonImage.sprite = SpriteBackgroundImage;
            winText.text = "Sprite Wins !";
        }
        ResetButtonImage.gameObject.GetComponent<Button>().Select();
    }

    void StartWait(GameObject _victoriousBottle)
    {
        StartCoroutine(Wait(_victoriousBottle));
    }

    IEnumerator Wait(GameObject _victoriousBottle)
    {
        yield return new WaitForSeconds(0.5f);
        DisplayWin(_victoriousBottle);
    }

}
