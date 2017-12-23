using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PowerupManager : MonoBehaviour {
    private bool doublePoints;
    private bool safeMode;
    private bool powerupActive;
    private bool doubleCoin;
    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGanaretor;
    private float spikeRate;
    private float normalPointsPerSecond;
    private PlatformDestroyer[] spikeList;


    private float powerupLengthCounter;
    private GameManager theGameManager;
    public popupText thepopuptext;
   
    
    
   

	// Use this for initialization
	void Start () {

        thePlatformGanaretor = FindObjectOfType<PlatformGenerator>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theGameManager = FindObjectOfType<GameManager>();

		
	}
	
	// Update is called once per frame
	void Update () {
        if (powerupActive)
        {
            
            powerupLengthCounter -= Time.deltaTime;
            if (theGameManager.powerupReset)
            {
                powerupLengthCounter = 0;
                theGameManager.powerupReset = false;
            }

            if (doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2;
                theScoreManager.shouldDouble = true;
            }

            if (safeMode)
            {
                thePlatformGanaretor.randomSpikesThreshold = 0f;
            }
            if (doubleCoin)
            {
                theScoreManager.doubleCoin = true;
            }
            


            if (powerupLengthCounter <= 0)
            {
                thePlatformGanaretor.randomSpikesThreshold = spikeRate;
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                powerupActive = false;
                theScoreManager.shouldDouble = false;
                theScoreManager.doubleCoin = false;

            }
        }

		
	}


    public void ActivatePowerup(bool points, bool safe,bool coinDouble, float time)
    
    {

        doublePoints = points;
        safeMode = safe;
        doubleCoin = coinDouble;
        thepopuptext.PopupUpdate(safeMode, doublePoints,coinDouble);
        powerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        spikeRate = thePlatformGanaretor.randomSpikesThreshold;
        powerupActive = true;
        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < spikeList.Length; i++)
            {
                if (spikeList[i].gameObject.name.Contains("spikes"))
                {
                    spikeList[i].gameObject.SetActive(false);

                }
            }
        }


    }
    
}
