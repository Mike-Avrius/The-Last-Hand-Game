using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    
    public GameObject pausePanel;
    
    // disables pause bar from game start
    void Start()
    {
       pausePanel.SetActive(false); 
    }

    //checks - if Escape is pressed - runs pause method
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            pausePanel.SetActive(true);
        }
    }

    //stops time
    public void Pause()
    {
        Time.timeScale = 0;
    }
    
    //Restores game speed (runs via button)
    public void Continue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    //goes to the main menu(runs via button)
    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    
}
