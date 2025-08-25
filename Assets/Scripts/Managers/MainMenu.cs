using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Menu buttons")]
    public Button startButton;
    public Button exitButton;
    public Button controlsButton;
    public Button returnButton;

    public GameObject controlsPanel;

    public bool controlsPanelIsOpened;
    
    [Header("Difficulty buttons")]
    public Button easyButton;
    public Button normalButton;
    public Button hardModeButton;

    // turns off returnButton, Difficulty buttons and a control panel
    private void Start()
    {
        returnButton.gameObject.SetActive(false);
        easyButton.gameObject.SetActive(false);
        normalButton.gameObject.SetActive(false);
        hardModeButton.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(false);
    }

    // turns on returnButton, Difficulty buttons and turns off starts buttons and to be sure control panel
    public void DifficultyButtonsActivation()
    {
        easyButton.gameObject.SetActive(true);
        normalButton.gameObject.SetActive(true);
        hardModeButton.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        controlsButton.gameObject.SetActive(false);
    }
    
    //returns to menu panel if controls Panel was Opened -> turns on buttons
    public void ReturnToMainButtons()
    {
        if (controlsPanelIsOpened)
        {
            controlsPanel.gameObject.SetActive(false);
            controlsPanelIsOpened = false;
        }
        else
        {
            easyButton.gameObject.SetActive(false);
            normalButton.gameObject.SetActive(false);
            hardModeButton.gameObject.SetActive(false);
            returnButton.gameObject.SetActive(false);
        
            startButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
            controlsButton.gameObject.SetActive(true);
        }
    }
    
    //turns on Controls panel
    public void OpenControlsPanel()
    {
        controlsPanel.gameObject.SetActive(true);
        controlsPanelIsOpened = true;
    }
    
    
    // Close the application or if running in the Unity Editor, stop the play mode
    public void Exit()
    {
       
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
    

    // load the Play Zone scene and setcoins/lifes to player and opponent
    public void DownloadEasyLevel()
    {
        SceneManager.LoadScene("Play Zone");
        DifficultyChoiseManager._OpponentCoins = 6;
        DifficultyChoiseManager._PlayerCoins = 6;
        
    }
    public void DownloadNormalLevel()
    {
        SceneManager.LoadScene("Play Zone");
        DifficultyChoiseManager._PlayerCoins = 4;
        DifficultyChoiseManager._OpponentCoins = 4;
    }
    public void DownloadHardLevel()
    {
        DifficultyChoiseManager._PlayerCoins = 1;
        DifficultyChoiseManager._OpponentCoins = 1;
        SceneManager.LoadScene("Play Zone");
    }
}
