using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MemoryPlayers : MonoBehaviour
{
    public int CurrentPlayer { get; private set; } = 0;
    private int[] _playerScore  = { 0, 0, 0, 0 };

    private int _playerNumber = 3;

    public void ChangePlayer()
    {
        Debug.Log($"Change Player To{CurrentPlayer}");
        CurrentPlayer = (CurrentPlayer + 1) % _playerNumber;
    }

    public void IncreaseScore()
    {
        _playerScore[CurrentPlayer] += 1;
    }

    public int GetCurrentPlayerScore()
    {
        return _playerScore[CurrentPlayer];
    }

    public int[] PlayerWinner()
    {
        int highestScore = 0;

        for (int i = 0; i < _playerScore.Length; i++)
        {
            if (highestScore < _playerScore[i])
            {
                highestScore = _playerScore[i];
            }
        }

        int[] winners = { -1, -1, -1, -1 };
        int winnersIndex = 0;

        for (int i = 0; i < _playerScore.Length; i++)
        {
            if (_playerScore[i] == highestScore)
            {
                winners[winnersIndex] = i;
                winnersIndex++;
            }
        }

        return winners;

        //Il y a un nombre impair de paires, empêchant une égalité
    }
}
