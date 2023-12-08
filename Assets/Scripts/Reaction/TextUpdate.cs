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

    [SerializeField] NumberOfPlayer selectedPlayers;
    [SerializeField] int nbPlayers;
    [SerializeField] float[] playersTimes;
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

    [SerializeField] TextMeshProUGUI game_text;
    [SerializeField] GameObject background;
    [SerializeField] Material black;
    [SerializeField] Material white;

    [SerializeField] GameObject menuButton;

    private void Awake() {
        selectedPlayers.OnNumberOfPlayersChanged += SelectPlayers;
    }

    void Start()
    {
        menuButton.SetActive(false);

        playersTimes = new float[nbPlayers];

        background.GetComponent<Renderer>().material = black;
        int rand = Random.Range(0, 3);
        Debug.Log("Select Game Text : " + rand);
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

    void SelectPlayers(int nbPlayer) {
        nbPlayers = nbPlayer;
    }

    void Update() {
        if (isFinished) {
            game_text.color = Color.black;

            if(nbPlayers == 2) {
                if (timeJ1 != 0 && timeJ2 != 0) {
                    playersTimes[0] = timeJ1;
                    playersTimes[1] = timeJ2;
                    FindWinner();
                }
            }
            if(nbPlayers == 3) {
                if (timeJ1 != 0 && timeJ2 != 0 && timeJ3 != 0) {
                    playersTimes[0] = timeJ1;
                    playersTimes[1] = timeJ2;
                    playersTimes[2] = timeJ3;
                    FindWinner();
                }
            }
            if(nbPlayers == 4) {
                if (timeJ1 != 0 && timeJ2 != 0 && timeJ3 != 0 && timeJ4 != 0) {
                    playersTimes[0] = timeJ1;
                    playersTimes[1] = timeJ2;
                    playersTimes[2] = timeJ3;
                    playersTimes[3] = timeJ4;
                    FindWinner();
                }
            }
            
            

            menuButton.SetActive(true);

        }
    }

    void FindWinner() {
        float min = playersTimes[0];
        if (nbPlayers == 2) {
            foreach (var time in playersTimes) {
                if (time < min) {
                    min = time;
                }
            }
            if (timeJ1 == min) {
                game_text.text = "Coca-Cola wins !";
            }
            if (timeJ2 == min) {
                game_text.text = "Pepsi wins !";
            }
            if (timeJ1 == timeJ2) {
                game_text.text = "Draw !";
            }
        }
        if (nbPlayers == 3) {
            foreach (var time in playersTimes) {
                if (time < min) {
                    min = time;
                }
            }

            if (timeJ1 == min) {
                game_text.text = "Coca-Cola wins !";
            }
            if (timeJ2 == min) {
                game_text.text = "Pepsi wins !";
            }
            if (timeJ3 == min) {
                game_text.text = "Fanta wins !";
            }
            if (timeJ1 == timeJ2 && timeJ1 == timeJ3) {
                game_text.text = "Draw !";
            }
        }
        if (nbPlayers == 4) {
            foreach (var time in playersTimes) {
                if (time < min) {
                    min = time;
                }
            }

            if (timeJ1 == min) {
                game_text.text = "Coca-Cola wins !";
            }
            if (timeJ2 == min) {
                game_text.text = "Pepsi wins !";
            }
            if (timeJ3 == min) {
                game_text.text = "Fanta wins !";
            }
            if (timeJ4 == min) {
                game_text.text = "Sprite wins !";
            }
            if (timeJ1 == timeJ2 && timeJ1 == timeJ3 && timeJ1 == timeJ4) {
                game_text.text = "Draw !";
            }
        }

        if(Leaderboards.instance != null) {
            if(Leaderboards.instance.ReactionLoadScore() == 0) {
                Leaderboards.instance.ReactionSaveScore(100000);
            }
            Leaderboards.instance.ReactionSaveScore(Mathf.Min(Leaderboards.instance.ReactionLoadScore(), min));
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
        yield return new WaitForSeconds(0.5f);
        game_text.text = "";
        yield return new WaitForSeconds(0.25f);
        game_text.text = tabText[1];    // Chucklenuts
        yield return new WaitForSeconds(0.5f);
        background.GetComponent<Renderer>().material = white;
        game_text.text = "";
        isFinished = true;
        yield return null;
    }
    IEnumerator TextUpdaterNumber(string[] tabText) {
                                        // 5
        yield return new WaitForSeconds(0.5f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[1];    // 4
        yield return new WaitForSeconds(0.5f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[2];    // 3
        yield return new WaitForSeconds(0.5f);
        game_text.text = "";
        yield return new WaitForSeconds(0.5f);
        game_text.text = tabText[3];    // 2
        yield return new WaitForSeconds(0.5f);
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
