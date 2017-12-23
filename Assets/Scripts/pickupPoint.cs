using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoint : MonoBehaviour {

    public int scoreToGive;
    private ScoreManager theScoreManager;
    private AudioSource coinSound;


	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("coinSound").GetComponent<AudioSource>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            if (coinSound.isPlaying)
            {
                coinSound.Stop();
				coinSound.pitch = Random.Range(0.45f, 0.60f);
				coinSound.volume = Random.Range(0.1f, 0.30f);
                coinSound.Play();
            }
            else
            {
				coinSound.pitch = Random.Range(0.40f, 0.60f);
				coinSound.volume = Random.Range(0.1f, 0.30f);
                coinSound.Play();
            }
        }
    }
}
