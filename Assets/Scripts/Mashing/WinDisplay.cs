using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinDisplay : MonoBehaviour
{
    //Store the win canvas component
    [SerializeField]Canvas winCanvas;
    [SerializeField]Image winImage;
    [SerializeField]TMP_Text winText;

    //Store the shake script to know when the game is finished
    [SerializeField]ShakeByInputSystem ShakeScript;

    //Store the background image for the win text
    [SerializeField]Sprite CocaBackgroundImage;
    [SerializeField]Sprite PepsiBackgroundImage;
    [SerializeField]Sprite FantaBackgroundImage;
    [SerializeField]Sprite SpriteBackgroundImage;


    private void Start()
    {
        ShakeScript.OnWinReached += DisplayWin;
    }

    void DisplayWin(GameObject victoriousBottle)
    {
        if (victoriousBottle.name == "Coca")
        {
            winCanvas.gameObject.SetActive(true);
            winImage.sprite = CocaBackgroundImage;
            winText.text = "Coca Wins !";
        }
        else if (victoriousBottle.name == "Pepsi")
        {
            winCanvas.gameObject.SetActive(true);
            winImage.sprite = PepsiBackgroundImage;
            winText.text = "Pepsi Wins !";
        }
        else if (victoriousBottle.name == "Fanta")
        {
            winCanvas.gameObject.SetActive(true);
            winImage.sprite = FantaBackgroundImage;
            winText.text = "Fanta Wins !";
        }
        else if (victoriousBottle.name == "Sprite")
        {
            winCanvas.gameObject.SetActive(true);
            winImage.sprite = SpriteBackgroundImage;
            winText.text = "Sprite Wins !";
        }
    }

}
