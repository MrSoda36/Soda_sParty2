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
        mashingScoreText.text = Leaderboards.instance.MashingLoadScore().ToString();
    }

    public void UpdateReactionScore() {
        reactionScoreText.text = Leaderboards.instance.ReactionLoadScore().ToString();
    }

    public void UpdateMemoryScore() {
        memoryScoreText.text = Leaderboards.instance.MemoryLoadScore().ToString();
    }
}
