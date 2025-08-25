using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Texts")] 
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI drawText;
    [SerializeField] private TextMeshProUGUI minusHands;
    
    [Header("Button")] 
    public Button returnSpeedButton;
    public Button playAgainButton;
    public Button playButton;
    public Button minusRightHandButton;
    public Button minusLeftHandButton;
    
    [Header("Scripts")]
    public PlayerControls _PlayerMovement;
    public CreditPanelMovement _CreditPanelMovement;
    
    [Header("Bools")]
    public bool isWalking = false;
    
    
    //updates UI with the required number
    public void UpdateUI(int amount)
    {
        scoreText.text = amount.ToString();
    }

    //disables the speed return button and also disables the texts of the Draw
    private void Start()
    {
        DeactivateDrawText();
        returnSpeedButton.gameObject.SetActive(false);
    }

    //Enables the button to return the player's speed
    public void AvtivateReturnBurron()
    {
        returnSpeedButton.gameObject.SetActive(true);
    }

    //Enables the texts of the Draw
    public void ActivateDrawText()
    {
        drawText.gameObject.SetActive(true);
    }
    
    //disables the texts of the Draw
    public void DeactivateDrawText()
    {
        drawText.gameObject.SetActive(false);
    }

    //disables the texts of the Draw
    //returns the player to his previous speed
    //turns off the button to play again
    //sets a flag that the player can move in truth - checked in the game manager
    public void ReturnSpeed()
    {
        _PlayerMovement.speadMovement = 7f;
        DeactivateDrawText();
        returnSpeedButton.gameObject.SetActive(false);
        isWalking = true;
        DiactivatePlayBytton();
    }
    
    //disables the buttons that allow you to play again
    public void DeacrivateReplayabilityButtons()
    {
        returnSpeedButton.gameObject.SetActive(false);
        DiactivatePlayAgainBytton();
    }

    //launches the caption panel
    public void PlayCredits()
    {
        DeacrivateReplayabilityButtons();
        _CreditPanelMovement.CreditsPanel();
    }

    //Dis-activate play button
    public void ActivatePlayBytton()
    {
        playButton.gameObject.SetActive(true);
    }
    public void DiactivatePlayBytton()
    {
        playButton.gameObject.SetActive(false); 
    }
    
    //Dis-activate play again button
    public void ActivatePlayAgainBytton()
    {
        playAgainButton.gameObject.SetActive(true);
    }
    public void DiactivatePlayAgainBytton()
    {
        playAgainButton.gameObject.SetActive(false); 
    }
    
    //Dis-activate minus hands buttons
    public void ActivateMinusRightHandBytton()
    {
        minusRightHandButton.gameObject.SetActive(true);
    }
    public void DiactivateMinusRightHandBytton()
    {
        minusRightHandButton.gameObject.SetActive(false); 
    }
    public void ActivateMinusLeftHandBytton()
    {
        minusLeftHandButton.gameObject.SetActive(true);
    }
    public void DiactivateMinusLeftHandBytton()
    {
        minusLeftHandButton.gameObject.SetActive(false); 
    }
    
    //Dis-activate minus hands texts
    public void ActivateMinusHandText()
    {
        minusHands.gameObject.SetActive(true);
    }
    public void DiactivateMinusHandText()
    {
        minusHands.gameObject.SetActive(false); 
    }
}
