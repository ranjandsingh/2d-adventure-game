using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    //private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    //private Vector3 playerStartPoint;
    public DeathMenu theDethMenu;
    public PauseMenu thePauseMenu;

    private PlatformDestroyer[] platformList;
    private ScoreManager theScoreManager;
    public bool powerupReset;
    public bool parallaxReset;
    public GameObject health;
    public bool GotAds;
   
    public GameObject beforeDeathMenu;
    private float totalCoin;
    public float timeMultiplier;
    public float pointsMuiltiplier;
    private int playerIndex;
    public GameObject tutorialUI;
    public GameObject FallenMenu;
    

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            totalCoin = PlayerPrefs.GetFloat("TotalCoins");
            tutorialUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            tutorialUI.SetActive(true);
            
        }
        theDethMenu.gameObject.SetActive(false);

        /*platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;*/
        theScoreManager = FindObjectOfType<ScoreManager>();
        if (PlayerPrefs.HasKey("PlayerSelected"))
        {
            playerIndex = PlayerPrefs.GetInt("PlayerSelected");
        }
        switch (playerIndex)
        {
            case 0: 
                pointsMuiltiplier = 1f;
                timeMultiplier = 1f;
                break;
            case 1: 
                pointsMuiltiplier = 1.5f;
                timeMultiplier = 1f;
                break;
            case 2: 
                pointsMuiltiplier = 1.5f;
                timeMultiplier = 1.5f;
                break;
            case 3: 
                pointsMuiltiplier = 2f;
                timeMultiplier = 1.5f;
                break;
            case 4: 
                pointsMuiltiplier = 2.5f;
                timeMultiplier = 2f;
                break;
        }



	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void RestartGame()
    {
        
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        health.gameObject.SetActive(false);
        thePauseMenu.gameObject.SetActive(false);
        totalCoin += theScoreManager.coincount;
        PlayerPrefs.SetFloat("TotalCoins", totalCoin);
        FallenMenu.gameObject.SetActive(false);
        beforeDeathMenu.gameObject.SetActive(true);
		//theDethMenu.gameObject.SetActive (true);

        
        
       // StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        powerupReset = true;
        parallaxReset = true;
        
        SceneManager.LoadScene("Endless");


       
        /*
        theDethMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        thePauseMenu.gameObject.SetActive(true);
        */

    }

    public void playerKilled()
    {
        beforeDeathMenu.SetActive(false); 
        theDethMenu.gameObject.SetActive(true);

    }

    public void fallen()
    {
        StartCoroutine(FallenDawn());
    }
    IEnumerator FallenDawn()
    {
        thePlayer.gameObject.SetActive(false);
        //Time.timeScale = 0f;
        theScoreManager.scoreIncreasing = false;
        FallenMenu.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        FallenMenu.gameObject.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreIncreasing = true;
        thePlayer.transform.position = new Vector3(thePlayer.lastGround.position.x, thePlayer.lastGround.position.y + 2, thePlayer.lastGround.position.z);
    }
    public void SpwanPlayer()
    {
        beforeDeathMenu.SetActive(false);
        theScoreManager.scoreIncreasing = true;
        health.gameObject.SetActive(true);
        thePauseMenu.gameObject.SetActive(false);
        thePlayer.damage = 3;
        thePlayer.transform.position = new Vector3(thePlayer.lastGround.position.x, thePlayer.lastGround.position.y + 2, thePlayer.lastGround.position.z);
        thePlayer.gameObject.SetActive(true);
       
        //GotAds = true;
    }
    

}
