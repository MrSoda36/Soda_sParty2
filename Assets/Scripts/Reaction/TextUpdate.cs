using System.Collections;
using TMPro;
using UnityEngine;

public class TextUpdate : MonoBehaviour
{
    string[] pepsiText = new string[] {
        "A Pepsi bottle",
        "A Coca-Cola glass",
        "I don't give a-"
    };
    string[] chucklenutsText = new string[] {
        "Think fast",
        "Chucklenuts"
    };
    string[] numberText = new string[] {
        "5",
        "4",
        "3",
        "2",
        "1"
    };

    public bool isFinished = false;
    public float timeJ1 {
        get; set;
    }
    public float timeJ2 {
        get; set;
    }
    public float timeJ3 {
        get; set;
    }
    public float timeJ4 {
        get; set;
    }

    public TextMeshProUGUI game_text;
    public GameObject background;
    public Material black;
    public Material white;

    public GameObject menuButton;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.SetActive(false);

        background.GetComponent<Renderer>().material = black;
        int rand = Random.Range(0, 2);
        switch (rand) {
            case 0:
                game_text.text = pepsiText[0];
                StartCoroutine(TextUpdaterPepsi(pepsiText));
                break;
            case 1:
                game_text.text = chucklenutsText[0];
                StartCoroutine(TextUpdaterChucklenuts(chucklenutsText));
                break;
            case 2:
                game_text.text = numberText[0];
                StartCoroutine(TextUpdaterNumber(numberText));
                break;
        }
    }

    void Update() {
        if (isFinished) {
            game_text.color = Color.black;
            if(timeJ1 != 0 && timeJ2 != 0 && timeJ3 != 0 && timeJ4 != 0) {
                if (timeJ1 < timeJ2) {
                    if (timeJ1 < timeJ3) {
                        if (timeJ1 < timeJ4) {
                            game_text.text = "Coca-Cola a gagn� !";
                        }
                    }
                }
                else if (timeJ2 < timeJ1) {
                    if (timeJ2 < timeJ3) {
                        if (timeJ2 < timeJ4) {
                            game_text.text = "Pepsi a gagn� !";
                        }
                    }
                }
                else if (timeJ3 < timeJ1) {
                    if (timeJ3 < timeJ2) {
                        if (timeJ3 < timeJ4) {
                            game_text.text = "Fanta a gagn� !";
                        }
                    }
                }
                else if (timeJ4 < timeJ1) {
                    if (timeJ4 < timeJ2) {
                        if (timeJ4 < timeJ3) {
                            game_text.text = "Sprite a gagn� !";
                        }
                    }
                }
                else {
                    game_text.text = "Egalit� !";
                }
                menuButton.SetActive(true);
            }
            
        }
    }


    IEnumerator TextUpdaterPepsi(string[] tabText) {
                                        // A Pepsi bottle
        yield return new WaitForSeconds(2.0f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[1];    // A Coca-Cola glass
        yield return new WaitForSeconds(2.0f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[2];    // I don't give a-
        yield return new WaitForSeconds(0.5f);
        background.GetComponent<Renderer>().material = white;
        game_text.text = "";
        isFinished = true;
        yield return null;
    }

    IEnumerator TextUpdaterChucklenuts(string[] tabText) {
                                        // Think fast
        yield return new WaitForSeconds(1.0f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[1];    // Chucklenuts
        yield return new WaitForSeconds(0.5f);
        background.GetComponent<Renderer>().material = white;
        game_text.text = "";
        isFinished = true;
        yield return null;
    }
    IEnumerator TextUpdaterNumber(string[] tabText) {
                                        // 5
        yield return new WaitForSeconds(2.0f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[1];    // 4
        yield return new WaitForSeconds(2.0f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[2];    // 3
        yield return new WaitForSeconds(2.0f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[3];    // 2
        yield return new WaitForSeconds(2.0f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[4];    // 1
        yield return new WaitForSeconds(0.5f);
        background.GetComponent<Renderer>().material = white;
        game_text.text = "";
        isFinished = true;
        yield return null;
    }

}
