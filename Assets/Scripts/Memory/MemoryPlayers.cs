using UnityEngine;

public class MemoryPlayers : MonoBehaviour
{
    [SerializeField] private int _playerNumber = 3;
    public int CurrentPlayer { get; private set; } = 0;
    private int[] _playerScore  = { 0, 0, 0, 0 };

    //Sets the number of players currently playing

    public void SetPlayerNumber(int num)
    {
        _playerNumber = num;
    }
    
    //Switches to the next player
    public void ChangePlayer()
    {
        CurrentPlayer = (CurrentPlayer + 1) % _playerNumber;
    }

    //Increases the current player's 
    public void IncreaseScore()
    {
        _playerScore[CurrentPlayer] += 1;
    }

    //Returns the current player's score
    public int GetCurrentPlayerScore()
    {
        return _playerScore[CurrentPlayer];
    }

    //returns the index of the players with the highest score
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

        if (highestScore > Leaderboards.instance.MemoryLoadScore())     //Leaderboard highest ever score
        {
            Leaderboards.instance.MemorySaveScore(highestScore);
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
    }
}
