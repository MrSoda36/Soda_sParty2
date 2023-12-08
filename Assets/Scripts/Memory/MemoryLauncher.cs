using System.Collections;
using UnityEngine;

public class MemoryLauncher : MonoBehaviour
{
    [SerializeField] private MemoryBehaviour _behaviour;
    [SerializeField] private MemoryUI _ui;
    [SerializeField] private MemoryInput _input;

    private bool _waitingForKey = false;
    private bool _keyPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        _input.OnKeyPressed += KeyListener;
        StartCoroutine(InitGame());
    }

    private IEnumerator InitGame()
    {
        _behaviour.ExtractCardInfo();

        _ui.Initialize();
        yield return StartCoroutine(WaitForInput());
        _ui.HidePanel();

        StartCoroutine(_behaviour.GamePlay());

        yield return null;
    }

    private IEnumerator WaitForInput()
    {
        _waitingForKey = true;

        yield return new WaitUntil(() => _keyPressed);

        _keyPressed = false;
        _waitingForKey = false;
    }

    private void KeyListener()
    {
        if (_waitingForKey)
        {
            _keyPressed = true;
        }
    }
}
