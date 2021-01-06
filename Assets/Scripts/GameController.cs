using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public int scoreToWin;

    public GameObject goal;
    private bool hasWon = false;

    public static int currLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(score == scoreToWin && !hasWon)
        {
            Debug.Log("You Win!");
            Instantiate(goal, new Vector3(0.05f, 0.5f, 0.17f), Quaternion.identity);
            hasWon = true;
        }        
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

    //loads next level upon completion of current level
    public static void CompleteLevel()
    {
        currLevel += 1;
        SceneManager.LoadScene(currLevel);
    }
}
