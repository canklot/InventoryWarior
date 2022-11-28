using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ThePlayer;
    Character CharacterScript;
    HeathBarClass PlayerHealthBar;

    [SerializeField]
    GameObject GameOverCanvas;

    [SerializeField]
    TextMeshProUGUI ScorTextMesh;

    // Start is called before the first frame update
    void Start()
    {
        CharacterScript = ThePlayer.GetComponent<Character>();
        PlayerHealthBar = ThePlayer.GetComponent<HeathBarClass>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealthBar.isDead)
        {
            Debug.Log("dead");
            GameOverCanvas.SetActive(true);
        }
    }
}
