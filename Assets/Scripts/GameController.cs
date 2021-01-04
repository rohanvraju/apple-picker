using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int scoreVal)
    {
        score += scoreVal;
        updateScoreboard();
    }

    public void updateScoreboard()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
