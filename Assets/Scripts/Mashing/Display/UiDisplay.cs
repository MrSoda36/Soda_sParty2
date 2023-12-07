using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Linq;

public class UiDisplay : MonoBehaviour
{
    //Store the number of players reference
    [Header("Player References")]
    [SerializeField] NumberOfPlayer _playerNb;

    //Store the UI references
    [Header("UI References")]
    [SerializeField] GameObject UiParentForNumberOfPlayer;
    [SerializeField] GameObject UiTwoPlayer;
    [SerializeField] GameObject UiSeparatePlayer;
    [SerializeField] TMP_Text GamepadConected;

    [Header("Binding Text")]
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] TMP_Text CocaBindingText;
    [SerializeField] TMP_Text PepsiBindingText;
    [SerializeField] TMP_Text FantaBindingText;
    [SerializeField] TMP_Text SpriteBindingText;

    [Header("Input Manager")]
    [SerializeField] InputManager _inputManager;


    private void Start()
    {
        _playerNb.OnNumberOfPlayersChanged += DisplayUI;
        _playerNb.OnNumberOfPlayersChanged += DisplayBindingText;

        _inputManager.OnGamepadConnected += UpdateGamePadText;
        UpdateGamePadText(InputSystem.devices.OfType<Gamepad>().Count());
    }

    void DisplayUI(int NbPlayer)
    {
        UiParentForNumberOfPlayer.SetActive(false);
        if (NbPlayer == 2)
        {
            UiTwoPlayer.SetActive(true);
            CocaBindingText.rectTransform.position = new Vector3(CocaBindingText.rectTransform.position.x, CocaBindingText.rectTransform.position.y + 10, CocaBindingText.rectTransform.position.z);
            PepsiBindingText.rectTransform.position = new Vector3(PepsiBindingText.rectTransform.position.x, PepsiBindingText.rectTransform.position.y + 10, PepsiBindingText.rectTransform.position.z);
        }
        else
        {
            UiSeparatePlayer.SetActive(true);
        }
    }

    void DisplayBindingText(int i)
    {
        CocaBindingText.text = "Press : " + InputControlPath.ToHumanReadableString(_playerInput.actions["FirstPlayer"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)
            + " or " + InputControlPath.ToHumanReadableString(_playerInput.actions["FirstPlayerGamepad"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        PepsiBindingText.text = "Press : " + InputControlPath.ToHumanReadableString(_playerInput.actions["SecondPlayer"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)
            + " or " + InputControlPath.ToHumanReadableString(_playerInput.actions["SecondPlayerGamepad"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        FantaBindingText.text = "Press : " + InputControlPath.ToHumanReadableString(_playerInput.actions["ThirdPlayer"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)
            + " or " + InputControlPath.ToHumanReadableString(_playerInput.actions["ThirdPlayerGamepad"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        SpriteBindingText.text = "Press : " + InputControlPath.ToHumanReadableString(_playerInput.actions["FourthPlayer"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)
            + " or " + InputControlPath.ToHumanReadableString(_playerInput.actions["FourthPlayerGamepad"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    public void UpdateGamePadText(int i)
    {
        if (i == 0)
        {
            GamepadConected.text = " No Gamepad Connected ";
        }
        else
        {
            GamepadConected.text = "Gamepad Connected : " + i.ToString();
        }
    }
}
