using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject charecterMenu;
    public GameObject DefultMenu;
    public Text coinText;
    public float totalCoin;
    public int charecterAvalablity;
    public Text coinError;
    public GameObject Selectbtn;
    public GameObject Buybtn;
    

    void Start()
    {
        DefultMenu.SetActive(true);
        charecterMenu.SetActive(false);
        
        totalCoin = PlayerPrefs.GetFloat("TotalCoins");
        coinText.text = "Coins:-" + totalCoin;
        if (PlayerPrefs.HasKey("ChAvalablity"))
        {
            charecterAvalablity = PlayerPrefs.GetInt("ChAvalablity");
        }
        else
        {
            PlayerPrefs.SetInt("ChAvalablity", charecterAvalablity);
        }
    }
    public void BackToMain()
    {
        DefultMenu.SetActive(true);
        charecterMenu.SetActive(false);
    }

    public void PlayGame()
    {
        if (PlayerPrefs.HasKey("PlayerSelected"))
        {

            SceneManager.LoadScene("Endless");
        }
        else
        {
            changePlayer();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void changePlayer()
    {
        DefultMenu.SetActive(false);
        charecterMenu.SetActive(true);
        
        
    }
    public void BuyPlayer(float price, int index)
    {
        
        if (totalCoin >= price)
        {
            totalCoin -= price;
            PlayerPrefs.SetFloat("TotalCoins", totalCoin);
            coinText.text = "Coins:-" + totalCoin;
            charecterAvalablity += 1 << index;
            PlayerPrefs.SetInt("ChAvalablity", charecterAvalablity);

            
        }
        else
        {
            //coinError.text = "need more coin";
            //coinError.gameObject.SetActive(true);
            //StartCoroutine(Fade());

        }




    }
    IEnumerator Fade()
    {

        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
