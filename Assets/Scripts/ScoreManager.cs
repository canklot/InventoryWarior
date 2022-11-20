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
    private int Score = 0;

    void Update()
    {
        ManageScore();
    }

    public void ManageScore()
    {
        // Make sure player start position is zero
        Score = (int)ThePlayer.transform.position.z;
        ScoreTMP.text = Score.ToString();
    }
}
