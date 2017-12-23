using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUps : MonoBehaviour {

    public bool doublePoints;
    public bool safeMode;
    public bool doubleCoin;

    public float powerupLength;
    private PowerupManager thePowerManager;

    public Sprite[] powerupSprite;
    public AudioSource powerupSound;
    private GameManager theGameManager;
    

   


	// Use this for initialization
	void Start () {
        thePowerManager = FindObjectOfType<PowerupManager>();
        theGameManager = FindObjectOfType<GameManager>();
        powerupLength = powerupLength * theGameManager.timeMultiplier;
       
		
	}

    void Awake()
    {
        int powerupSelector = Random.Range(0, 3);
        switch (powerupSelector)
        {
            case 0: doublePoints = true;
                break;
            case 1: safeMode = true;
                break;
            case 2: doubleCoin = true;
                break;

        }
        GetComponent<SpriteRenderer>().sprite = powerupSprite[powerupSelector];

    }

	
	// Update is called once per frame
	void Update () {
       
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            
            thePowerManager.ActivatePowerup(doublePoints, safeMode,doubleCoin , powerupLength);
            powerupSound.pitch = Random.Range(0.4f, 0.75f);
            powerupSound.Play();
           
            

        }
        gameObject.SetActive(false);
    }
}
