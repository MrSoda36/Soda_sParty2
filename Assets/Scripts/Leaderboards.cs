using UnityEngine;

public class Leaderboards : MonoBehaviour
{
    public static Leaderboards instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(this);
        }
    }


    // Save the score for each game
    public void MashingSaveScore(float score) {
        PlayerPrefs.SetFloat("mashingScore", score);
    }

    public void ReactionSaveScore(float score) {
        PlayerPrefs.SetFloat("reactionScore", score);
    }

    public void MemorySaveScore(int score) {
        PlayerPrefs.SetInt("memoryScore", score);
    }

    // Load the score for each game
    public float MashingLoadScore() {
        return PlayerPrefs.GetFloat("mashingScore");
    }

    public float ReactionLoadScore() {
        return PlayerPrefs.GetFloat("reactionScore");
    }

    public int MemoryLoadScore() {
        return PlayerPrefs.GetInt("memoryScore");
    }
}
