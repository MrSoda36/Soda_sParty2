using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTextUpdate : MonoBehaviour
{
    public PlayerInput playerInput;
    public TextUpdate textUpdate;
    public TextMeshProUGUI playerText;
    public int playerNum;
    bool isDone = false;
    float reactTime = 0.00f;

    char[] letters = new char[] {
        'a',
        'a',
        'c',
        'd',
        'e',
        'f',
        'g',
        'h',
        'i',
        'j',
        'k',
        'l',
        'm',
        'n',
        'o',
        'p',
        'q',
        'r',
        's',
        't',
        'u',
        'v',
        'w',
        'x',
        'y',
        'z'
    };

    // Start is called before the first frame update
    void Start()
    {
        reactTime = 0.00f;
        if(playerNum == 1) {

            var p1Bindings = playerInput.actions["PlayerOne"].bindings; 
            var p1BindingsAccessor = playerInput.actions["PlayerOne"].ChangeBinding(0);
            p1BindingsAccessor = playerInput.actions["PlayerOne"].ChangeBinding(0).WithPath("<Keyboard>/" + letters[Random.Range(0, letters.Length)]);
            char p1LetterBindings = p1Bindings[0].path[p1Bindings[0].path.Length - 1];

            playerText.text = "Press [" + p1LetterBindings.ToString().ToUpper() + "]";
        }else if(playerNum == 2) {

            var p2Bindings = playerInput.actions["PlayerTwo"].bindings;
            var p2BindingsAccessor = playerInput.actions["PlayerTwo"].ChangeBinding(0);
            p2BindingsAccessor = playerInput.actions["PlayerTwo"].ChangeBinding(0).WithPath("<Keyboard>/" + letters[Random.Range(0, letters.Length)]);
            char p2LetterBindings = p2Bindings[0].path[p2Bindings[0].path.Length - 1];

            playerText.text = "Press [" + p2LetterBindings.ToString().ToUpper() + "]";
        }else if(playerNum == 3) {

            var p3Bindings = playerInput.actions["PlayerThree"].bindings;
            var p3BindingsAccessor = playerInput.actions["PlayerThree"].ChangeBinding(0);
            p3BindingsAccessor = playerInput.actions["PlayerThree"].ChangeBinding(0).WithPath("<Keyboard>/" + letters[Random.Range(0, letters.Length)]);
            char p3LetterBindings = p3Bindings[0].path[p3Bindings[0].path.Length - 1];

            playerText.text = "Press [" + p3LetterBindings.ToString().ToUpper() + "]";
        }else if(playerNum == 4) {

            var p4Bindings = playerInput.actions["PlayerFour"].bindings;
            var p4BindingsAccessor = playerInput.actions["PlayerFour"].ChangeBinding(0);
            p4BindingsAccessor = playerInput.actions["PlayerFour"].ChangeBinding(0).WithPath("<Keyboard>/" + letters[Random.Range(0, letters.Length)]);
            char p4LetterBindings = p4Bindings[0].path[p4Bindings[0].path.Length - 1];

            playerText.text = "Press [" + p4LetterBindings.ToString().ToUpper() + "]";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textUpdate.isFinished) {
            reactTime += Time.deltaTime;
        }


    }

    public void PlayerAction() {
        if(textUpdate.isFinished) {
            if (playerNum == 1) {
                if (!isDone) {
                    playerText.text = "Done !";
                    isDone = true;
                    playerText.text = reactTime.ToString("0.###");
                    textUpdate.timeJ1 = reactTime;
                }
            }
            if (playerNum == 2) {
                if (!isDone) {
                    playerText.text = "Done !";
                    isDone = true;
                    playerText.text = reactTime.ToString("0.###");
                    textUpdate.timeJ2 = reactTime;
                }
            }
            if (playerNum == 3) {
                if (!isDone) {
                    playerText.text = "Done !";
                    isDone = true;
                    playerText.text = reactTime.ToString("0.###");
                    textUpdate.timeJ3 = reactTime;
                }
            }
            if (playerNum == 4) {
                if (!isDone) {
                    playerText.text = "Done !";
                    isDone = true;
                    playerText.text = reactTime.ToString("0.###");
                    textUpdate.timeJ4 = reactTime;
                }
            }
        }
        
    }
}
