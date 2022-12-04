using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ThePlayer;
    Character CharacterScript;
    HeathBarClass PlayerHealthBar;

    [SerializeField]
    private ScoreManager TheScoreManager;

    [SerializeField]
    GameObject GameOverCanvas;

    [SerializeField]
    TextMeshProUGUI ScorTextMesh;

    // Start is called before the first frame update
    void Start()
    {
        CharacterScript = ThePlayer.GetComponent<Character>();
        PlayerHealthBar = ThePlayer.GetComponent<HeathBarClass>();
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealthBar.isDead)
        {
            Debug.Log("dead");
            string score = ScoreManager.Score.ToString();
            ScorTextMesh.text = $"Your Score was \n {score}";
            GameOverCanvas.SetActive(true);
        }
    }
}
