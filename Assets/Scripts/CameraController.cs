using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public PlayerController thePlayer;
	private Vector3 lastPlayerPosition;
	private float distanceToMove;
    public Camera theCamera;
    
    
	

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
		lastPlayerPosition = thePlayer.transform.position;
       
        
		
	}
	
	// Update is called once per frame
	void Update () {
		distanceToMove =thePlayer.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3(transform.position.x + distanceToMove,transform.position.y,transform.position.z);
		lastPlayerPosition = thePlayer.transform.position;
		
	}

    public void zoomIN()
    {
        if (thePlayer.transform.position.y > 6)
        {
            theCamera.orthographicSize = theCamera.orthographicSize + 1 * Time.deltaTime;
            if (theCamera.orthographicSize > 9)
            {
                theCamera.orthographicSize = 9; // Max size
            }

        }
 
    }

    public void ZoomOut()
    {
        theCamera.orthographicSize = theCamera.orthographicSize - 2 * Time.deltaTime;
        if (theCamera.orthographicSize < 5)
        {
            theCamera.orthographicSize = 5; // Min size 
        }
    }


}
