using TMPro;
using UnityEngine;

public class PlayerTextUpdate : MonoBehaviour
{
    public TextUpdate textUpdate;
    public TextMeshProUGUI playerText;
    public int playerNum;
    bool isDone = false;
    float reactTime = 0.00f;

    // Start is called before the first frame update
    void Start()
    {
        reactTime = 0.00f;
        if(playerNum == 1) {
            playerText.text = "Appuyez sur [C]";
        }else if(playerNum == 2) {
            playerText.text = "Appuyez sur [P]";
        }else if(playerNum == 3) {
            playerText.text = "Appuyez sur [F]";
        }else if(playerNum == 4) {
            playerText.text = "Appuyez sur [S]";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textUpdate.isFinished) {
            reactTime += Time.deltaTime;

            if (Input.GetKeyUp(KeyCode.C) && playerNum == 1) {
                if (!isDone) {
                    playerText.text = "Fait !";
                    isDone = true;
                    playerText.text = reactTime.ToString("0.###");
                    textUpdate.timeJ1 = reactTime;
                }

            }
            if (Input.GetKeyUp(KeyCode.P) && playerNum == 2) {
                if (!isDone) {
                    playerText.text = "Fait !";
                    isDone = true;
                    playerText.text = reactTime.ToString("0.###");
                    textUpdate.timeJ2 = reactTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.F) && playerNum == 3) {
                if (!isDone) {
                    playerText.text = "Fait !";
                    isDone = true;
                    playerText.text = reactTime.ToString("0.###");
                    textUpdate.timeJ3 = reactTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.S) && playerNum == 4) {
                if (!isDone) {
                    playerText.text = "Fait !";
                    isDone = true;
                    playerText.text = reactTime.ToString("0.###");
                    textUpdate.timeJ4 = reactTime;
                }
            }
        }


    }
}
