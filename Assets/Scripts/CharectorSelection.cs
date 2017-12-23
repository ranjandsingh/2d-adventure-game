using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharectorSelection : MonoBehaviour {
    private GameObject[] charecterList;
    private int index;
    public Text playerName;
    private MainMenu theMainMenu;
    private float price;
    public Text pointsText;
    public Text powerupText;
    private float pointsperSecond;
    private float powerupTime;


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
        playerName.text = charecterList[index].name;
        theMainMenu = FindObjectOfType<MainMenu>();
		
	}

    // Update is called once per frame
    void Update()
    {
        if ((theMainMenu.charecterAvalablity & 1 << index) == 1 << index)
        {
            theMainMenu.coinError.text = "Available";
            theMainMenu.coinError.gameObject.SetActive(true);
            theMainMenu.Buybtn.SetActive(false);
            theMainMenu.Selectbtn.SetActive(true);
        }
        else
        {

            theMainMenu.coinError.text = "Need " + price + " Coins";
            theMainMenu.coinError.gameObject.SetActive(true);
            theMainMenu.Buybtn.SetActive(true);
            theMainMenu.Selectbtn.SetActive(false);

        }
        
        switch (index)
        {
            case 0: price = 0;
                pointsperSecond = 1f;
                powerupTime = 1f;
                break;
            case 1: price = 250;
                 pointsperSecond = 1.5f;
                powerupTime = 1f;
                break;
            case 2: price = 500;
                 pointsperSecond = 1.5f;
                powerupTime = 1.5f;
                break;
            case 3: price = 750;
                 pointsperSecond = 2f;
                powerupTime = 1.5f;
                break;
            case 4: price = 1000;
                 pointsperSecond = 2.5f;
                powerupTime = 2f;
                break;
        }
        pointsText.text = "Points : X " + pointsperSecond;
        powerupText.text = "Powerup Time: X " + powerupTime;
	}
    public void ToggleLeft()
    {
        charecterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = charecterList.Length - 1;
        charecterList[index].SetActive(true);
        playerName.text = charecterList[index].name;
       

    }
    public void ToggleRight()
    {
        charecterList[index].SetActive(false);
        index++;
        if (index == charecterList.Length)
            index = 0;
        charecterList[index].SetActive(true);
        playerName.text = charecterList[index].name;
        


    }
    public void Selected()
    {
        PlayerPrefs.SetInt("PlayerSelected", index);
        SceneManager.LoadScene("Endless");
    }
    public void Buy()
    {
        theMainMenu.BuyPlayer(price,index);
    }
}
