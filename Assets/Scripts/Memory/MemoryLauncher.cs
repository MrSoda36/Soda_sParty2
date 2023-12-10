using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryLauncher : MonoBehaviour
{
    [SerializeField] private MemoryBehaviour _behaviour;
    [SerializeField] private MemoryUI _ui;
    [SerializeField] private MemoryPlayers _players;

    // Start is called before the first frame update
    void Start()
    {
        _ui.ShowInitPanel();
        _behaviour.ExtractCardInfo();
    }

    public void InitPlayers(int playerNumber)
    {
        _players.SetPlayerNumber(playerNumber);
        _ui.HideInitPanel();
        _ui.Initialize(playerNumber);

        StartCoroutine(_behaviour.GamePlay());
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
