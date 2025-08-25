using System;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerHandState
{
    NoChouce,
    Rock,
    Paper,
    Scissors
}

public class PlayerPlayMode : MonoBehaviour
{
    [Header("PlayerHandState")]
    public PlayerHandState playerRightHandChoice;
    public PlayerHandState playerLeftHandChoice;
    
    [Header("Animators")]
    public Animator playerLefthandAnimator;
    public Animator playerRighthandAnimator;
    
    [Header("Right Buttons")]
    public Button rightRockButton;
    public Button rightPapperButton;
    public Button rightScissorsButton;
    
    [Header("Left Buttons")]
    public Button leftRockButton;
    public Button leftPapperButton;
    public Button leftScissorsButton;
    
    [Header("Flags for buttons")]
    public bool leftHandWasChoused = false;
    public bool rightHandWasChoused = false;
   
    //Method make sure that in start player is without choice
    private void Start()
    {
        playerRightHandChoice = PlayerHandState.NoChouce;
        playerLeftHandChoice = PlayerHandState.NoChouce;
    }
    
    //3 Methods for UI button for RIGHT HAND that choose for player ROCK/PAPER/SCISSORS and deactivate other choice buttons
    //make rock/papper/scissors button not interactable
    // and make game manager understad that for right hand player did his choice
    public void RockRightHand()
    {
        playerRightHandChoice = PlayerHandState.Rock;
        rightPapperButton.gameObject.SetActive(false);
        rightScissorsButton.gameObject.SetActive(false);
        rightRockButton.interactable = false;

        rightHandWasChoused = true;
        
    }
    public void PaperRightHand()
    {
        playerRightHandChoice = PlayerHandState.Paper;
        rightScissorsButton.gameObject.SetActive(false);
        rightRockButton.gameObject.SetActive(false);
        rightPapperButton.interactable = false;
        
        rightHandWasChoused = true;
    }
    public void ScissorsRightHand()
    {
        playerRightHandChoice = PlayerHandState.Scissors;
        rightRockButton.gameObject.SetActive(false);
        rightPapperButton.gameObject.SetActive(false);
        rightScissorsButton.interactable = false;
        
        rightHandWasChoused = true;
    }
    
    //method that Activate each button for right hand and make them interactable
    public void RightButtonsTurnOn()
    {
        rightRockButton.gameObject.SetActive(true);
        rightRockButton.interactable = true;

        rightPapperButton.gameObject.SetActive(true);
        rightPapperButton.interactable = true;
        
        rightScissorsButton.gameObject.SetActive(true);
        rightScissorsButton.interactable = true;
    }
    
    //method that Deactivate each button for right hand
    public void RightButtonsTurnOFF()
    {
        rightRockButton.gameObject.SetActive(false);
        rightPapperButton.gameObject.SetActive(false);
        rightScissorsButton.gameObject.SetActive(false);
    }
    
    //3 Methods for UI button for LEFT HAND that choose for player ROCK/PAPER/SCISSORS and deactivate other choice buttons
    //make rock/papper/scissors button not interactable
    // and make game manager understad that for left hand player did his choice
    public void RockLeftHand()
    {
        playerLeftHandChoice = PlayerHandState.Rock;
        leftScissorsButton.gameObject.SetActive(false);
        leftPapperButton.gameObject.SetActive(false);
        leftRockButton.interactable = false;
        
        leftHandWasChoused = true;
    }
    public void PaperLeftHand()
    {
        playerLeftHandChoice = PlayerHandState.Paper;
        leftScissorsButton.gameObject.SetActive(false);
        leftRockButton.gameObject.SetActive(false);
        leftPapperButton.interactable = false;
        
        leftHandWasChoused = true;
    }
    public void ScissorsLeftHand()
    {
        playerLeftHandChoice = PlayerHandState.Scissors;
        leftPapperButton.gameObject.SetActive(false);
        leftRockButton.gameObject.SetActive(false);
        leftScissorsButton.interactable = false;
        
        leftHandWasChoused = true;
    }
    
    //method that Activate each button for left hand and make them interactable
    public void LeftButtonsTurnOn()
    {
        leftRockButton.gameObject.SetActive(true);
        leftRockButton.interactable = true;
        
        leftPapperButton.gameObject.SetActive(true);
        leftPapperButton.interactable = true;
        
        leftScissorsButton.gameObject.SetActive(true);
        leftScissorsButton.interactable = true;
    }
    
    //method that Deactivate each button for left hand
    public void LeftButtonsTurnOFF()
    {
        leftRockButton.gameObject.SetActive(false);
        leftPapperButton.gameObject.SetActive(false);
        leftScissorsButton.gameObject.SetActive(false);
    }
    
    //test method to check animation and script compiled right
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"Left hand is: {playerLeftHandChoice}");  
            Debug.Log($"Right hand is: {playerRightHandChoice}"); 
        }
        
    }
     
     
    //method that Activate animation for left hand for HandState
    public void LeftHandAnimatorON()
    {
        if (playerLeftHandChoice == PlayerHandState.Paper)
        {
            playerLefthandAnimator.SetBool("LeftIsPaper", true);
        }
        else if (playerLeftHandChoice == PlayerHandState.Rock)
        {
            playerLefthandAnimator.SetBool("LeftIsRock", true);
        }
        else if (playerLeftHandChoice == PlayerHandState.Scissors)
        {
            playerLefthandAnimator.SetBool("LeftIsScissors", true);
        }
    }
    
    //method that Deactivate animation for left hand if HandState is NoChoice
    public void LeftHandAnimatorOFF()
    {
        if (playerLeftHandChoice == PlayerHandState.NoChouce)
        {
            playerLefthandAnimator.SetBool("LeftIsPaper", false);
            playerLefthandAnimator.SetBool("LeftIsRock", false);
            playerLefthandAnimator.SetBool("LeftIsScissors", false);
        }
    }
    
    
    //method that Activate animation for right hand for HandState
    public void RightHandAnimatorON()
    {
        if (playerRightHandChoice == PlayerHandState.Paper)
        {
            playerRighthandAnimator.SetBool("RightIsPaper", true);
        }
        else if (playerRightHandChoice == PlayerHandState.Rock)
        {
            playerRighthandAnimator.SetBool("RightIsRock", true);
        }
        else if (playerRightHandChoice == PlayerHandState.Scissors)
        {
            playerRighthandAnimator.SetBool("RightIsScissors", true);
        }
    }
    
    //method that Deactivate animation for right hand if HandState is NoChoice
    public void RightHandAnimatorOFF()
    {
        if (playerRightHandChoice == PlayerHandState.NoChouce)
        {
            playerRighthandAnimator.SetBool("RightIsPaper", false);
            playerRighthandAnimator.SetBool("RightIsScissors", false);
            playerRighthandAnimator.SetBool("RightIsRock", false);
        }
    }
     
     
     
}