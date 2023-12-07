using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateLeaderboards : MonoBehaviour
{
    public TMP_Text mashingScoreText;
    public TMP_Text reactionScoreText;
    public TMP_Text memoryScoreText;

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
