using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    GameObject GameOverCanvas;

    [SerializeField]
    TextMeshProUGUI ScorTextMesh;

    // Start is called before the first frame update
    void Start()
    {
        string Score = ScoreManager.Score.ToString();
        ScorTextMesh.text = $"Your Score was \n {Score}";
    }

    // Update is called once per frame
    void Update() { }
}
