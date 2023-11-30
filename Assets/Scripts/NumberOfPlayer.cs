using System;
using UnityEngine;

public class NumberOfPlayer : MonoBehaviour
{
    int NumberOfPlayers;


    public event Action<int> OnNumberOfPlayersChanged;

    public void TwoPlayer()
    {
        NumberOfPlayers = 2;
        OnNumberOfPlayersChanged?.Invoke(NumberOfPlayers);
        return;
    }

    public void ThreePlayer()
    {
        NumberOfPlayers = 3;
        OnNumberOfPlayersChanged?.Invoke(NumberOfPlayers);
        return;
    }
    
    public void FourPlayer()
    {
        NumberOfPlayers = 4;
        OnNumberOfPlayersChanged?.Invoke(NumberOfPlayers);
        return;
    }

}
