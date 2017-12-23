using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	private float platformWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public ObjectPooler[] theObjectPools;
    //public GameObject[] thePlatforms;
    private int platformSelecter;
    private float[] platformWidths;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    public float randomSpikesThreshold;
    public ObjectPooler spikePool;

    public float powerupHeight;
    public ObjectPooler powerupPool;
    public float powerupThreshold;


	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        theCoinGenerator = FindObjectOfType<CoinGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
        
		if (transform.position.x < generationPoint.position.x)
		{
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelecter = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if (heightChange < minHeight)
            {
                    heightChange = minHeight;
            }

            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newPowerup = powerupPool.GetPooledObject();
                newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2, Random.Range(powerupHeight/2f, powerupHeight), 0f);
                newPowerup.SetActive(true);
            }
            
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelecter] / 2) + distanceBetween, heightChange,transform.position.z);
            
            //Instantiate (/*thePlatform*/ thePlatforms[platformSelecter], transform.position, transform.rotation);
            GameObject newPlatform = theObjectPools[platformSelecter].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            if (Random.Range(0f, 100f) < randomSpikesThreshold)
            {
                GameObject newSpike = spikePool.GetPooledObject();
                
                float spikeXPosition = Random.Range(-platformWidths[platformSelecter] / 2 + 1f, platformWidths[platformSelecter] / 2 - 1f);
                Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);
                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);

            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelecter] / 2), transform.position.y, transform.position.z);
		}
		
	}
}
