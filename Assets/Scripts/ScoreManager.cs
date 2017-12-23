using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    public Text hiScoreText;
    public Text CoinText;
    public float scoreCount;
    public Text DMcurrentScore;
    public Text DMHighScore;
   
    public float hiScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;
    public bool shouldDouble;
    public bool doubleCoin;
    public float coincount;
    private GameManager theGameManager;
    
 


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        theGameManager = FindObjectOfType<GameManager>();
        pointsPerSecond = pointsPerSecond * theGameManager.pointsMuiltiplier;
      
       
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }
        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);
        DMcurrentScore.text = "Current Score- " + Mathf.Round(scoreCount);
     
        CoinText.text = "Coins: " + coincount;
     ;        if (scoreCount > hiScoreCount)
        {
			DMHighScore.text = "New High Score!-> "  + Mathf.Round(hiScoreCount); ;
        }
        else
        {
            DMHighScore.text = "High Score- " + Mathf.Round(hiScoreCount);
        }


	}
    public void AddScore(int pointsToAdd)
    {
        if (shouldDouble)
        {
            scoreCount += pointsToAdd * 2;
            
        }
        if (doubleCoin)
        {
            coincount += 2;
        }
        else
        {
            coincount += 1;
        }
        scoreCount += pointsToAdd;
        
    }
}
 
