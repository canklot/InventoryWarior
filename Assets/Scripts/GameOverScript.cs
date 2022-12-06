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
        ActivateGameOverScreen();
    }

    // Update is called once per frame
    void Update() { }

    void ActivateGameOverScreen()
    {
        Debug.Log("dead");
        string Score = ScoreManager.Score.ToString();
        Debug.Log(Score);
        ScorTextMesh.text = $"Your Score was \n {Score}";
        GameOverCanvas.SetActive(true);
    }
}
