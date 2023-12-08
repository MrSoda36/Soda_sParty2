using System.Linq;
using UnityEngine;

public class MashingScore : MonoBehaviour
{
    public ShakeByInputSystem _shakeByInputSystem;

    //Defines if each player has started or not
    bool _cocaStarted = false;
    bool _pepsiStarted = false;
    bool _fantaStarted = false;
    bool _spriteStarted = false;

    //Sets the timer for each player (0=coca / 1=pepsi / 2=fanta / 3=sprite)
    [SerializeField] float[] _timers = new float[4];

    bool _finished = false;

    private void Start()
    {
        _shakeByInputSystem.OnStart += StartTimer;
        _shakeByInputSystem.OnWinReached += OnEnd;
    }
    private void FixedUpdate()
    {
        if (_cocaStarted && !_finished)
        {
            _timers[0] += Time.deltaTime;
        }
        if (_pepsiStarted && !_finished)
        {
            _timers[1] += Time.deltaTime;
        }
        if (_fantaStarted && !_finished)
        {
            _timers[2] += Time.deltaTime;
        }
        if (_spriteStarted && !_finished)
        {
            _timers[3] += Time.deltaTime;
        }
    }

    void OnEnd(GameObject _go)
    {
        _finished = true;
        Debug.Log(_timers.Min());
        float highestScore = Leaderboards.instance.MashingLoadScore();

        switch (_go.name)
        {
            case "Coca":
                if (_timers[0] < highestScore || highestScore == 0)
                {
                    Leaderboards.instance.MashingSaveScore(_timers[0]);
                }
                break;
            case "Pepsi":
                if (_timers[1] < highestScore || highestScore == 0)
                {
                    Leaderboards.instance.MashingSaveScore(_timers[1]);
                }
                break;
            case "Fanta":
                if (_timers[2] < highestScore || highestScore == 0)
                {
                    Leaderboards.instance.MashingSaveScore(_timers[2]);
                }
                break;
            case "Sprite":
                if (_timers[3] < highestScore || highestScore == 0)
                {
                    Leaderboards.instance.MashingSaveScore(_timers[3]);
                }
                break;
            default:
                break;
        }
    }

    void StartTimer(string name)
    {
        Debug.Log("Timer Started for " + name);
        switch (name)
        {
            case "Coca":
                _cocaStarted = true;
                break;
            case "Pepsi":
                _pepsiStarted = true;
                break;
            case "Fanta":
                _fantaStarted = true;
                break;
            case "Sprite":
                _spriteStarted = true;
                break;
        }
    }
}
