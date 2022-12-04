using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    GameObject ThePlayer;

    [SerializeField]
    TextMeshProUGUI ScoreTMP;
    public static int Score { get; private set; } = 0;

    void Update()
    {
        ManageScore();
    }

    public void ManageScore()
    {
        // Make sure player start position is zero
        Score = (int)ThePlayer.transform.position.z;
        string ScoreText = string.Format("Score: {0}", Score.ToString());
        ScoreTMP.text = ScoreText;
    }
}
