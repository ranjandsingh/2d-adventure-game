using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessPlayesSelector : MonoBehaviour {
    private GameObject[] charecterList;
    private int index;
    public Text playerName;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("PlayerSelected"))
        {
            index = PlayerPrefs.GetInt("PlayerSelected");
        }
        charecterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            charecterList[i] = transform.GetChild(i).gameObject;

        }
        foreach (GameObject go in charecterList)
        {
            go.SetActive(false);
        }
        if(charecterList[index])
        {
            charecterList[index].SetActive(true);
            
        }
        if (playerName != null)
        {
            playerName.text = charecterList[index].name;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void NextImage()
    {
        if (index < 2)
        {
            charecterList[index].SetActive(false);
            index += 1;
            charecterList[index].SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            
        }

    }
}
