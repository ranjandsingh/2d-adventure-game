using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Playad : MonoBehaviour {
    private GameManager theGameManager;

	// Use this for initialization
	void Start () {
        theGameManager = FindObjectOfType<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Showad()
    {
        if(Advertisement.IsReady())
          Advertisement.Show("", new ShowOptions() { resultCallback = HandleAdResult });
        
    }
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                theGameManager.SpwanPlayer();
                break;
            case ShowResult.Skipped:
                theGameManager.playerKilled();
                break;
            case ShowResult.Failed:
                theGameManager.playerKilled();
                
                break;
        }
    }
}
