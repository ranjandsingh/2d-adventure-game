using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWithParallax : MonoBehaviour {

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 17;
    private int leftIndex;
    private int rightIndex;

    public float backgroundsize;
    public float parallaxspeed;
    private float lastCameraX;
    public float bacgroundDistance;
    public float hieght;

    private GameManager theGM;

 

	// Use this for initialization
	void Start () {
         
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        
        leftIndex = 0;
        rightIndex = layers.Length - 1;

        theGM = FindObjectOfType<GameManager>();
        
		
	}

    // Update is called once per frame
    void Update()
    {
        if (theGM.parallaxReset)
        {
            leftIndex = 0;
            rightIndex = layers.Length - 1;
            theGM.parallaxReset = false;
        }
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX / parallaxspeed);
            lastCameraX = cameraTransform.position.x;
            /* if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
             {
                 ScrollLeft();
             }*/
            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            {
                ScrollRight();
            }
        
	}

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = new Vector3 (layers[leftIndex].position.x - backgroundsize, hieght, bacgroundDistance);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }


    }
    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = new Vector3 (layers[rightIndex].position.x + backgroundsize, hieght,bacgroundDistance);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
