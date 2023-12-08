using TMPro;
using UnityEngine;

public class UpdateLeaderboards : MonoBehaviour
{
    [SerializeField] private TMP_Text mashingScoreText;
    [SerializeField] private TMP_Text reactionScoreText;
    [SerializeField] private TMP_Text memoryScoreText;

    public void UpdateMashingScore() {
        mashingScoreText.text = "Best score of all time : \n" + Leaderboards.instance.MashingLoadScore().ToString("0.###");
    }

    public void UpdateReactionScore() {
        reactionScoreText.text = "Best score of all time : \n" + Leaderboards.instance.ReactionLoadScore().ToString("0.###");
    }

    public void UpdateMemoryScore() {
        memoryScoreText.text = "Best score of all time : \n" + Leaderboards.instance.MemoryLoadScore().ToString();
    }
}
