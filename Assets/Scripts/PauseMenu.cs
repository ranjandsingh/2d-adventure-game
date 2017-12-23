using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;
    
    public void PauseGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        

    }

    public void ResumeGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        
    } 

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(true);
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
        
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

