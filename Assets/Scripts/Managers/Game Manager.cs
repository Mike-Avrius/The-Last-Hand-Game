using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    [Header("Attached Script")]
    public PlayerPlayMode playerGame;
    public PlayerControls playerSetings;
    public OpponentPlayMode opponentGame;
    public OpponentHealthSystem _OpponentHealthSystem;
    public ScoreManager scoreManager;
    public CoinsSpawner coinSpawner;
    public UiManager _UiManager;
    
    [Header("Players Hands")]
    public GameObject playerRightHand;
    public GameObject playerLeftHand;
    private PlayerHandState resulTPlay;
    
    private bool minusRH = false;
    private bool minusLH = false;
    
    private GameObject opponentRightHand;
    private GameObject opponentLeftHand;

    public bool draw = false;
    
    public bool needToMinusOpponentFlaf = false;
    public bool playAgainFlag = false;
    
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Dis-activate play button
        _UiManager.DiactivatePlayBytton();
        
        //Dis-activate Minus hands text
        _UiManager.DiactivateMinusHandText();
        
        //Dis-activate Minus hands buttons
        _UiManager.DiactivateMinusLeftHandBytton();
        _UiManager.DiactivateMinusRightHandBytton();
        
        //Dis-activate player animations
        playerGame.RightButtonsTurnOFF();
        playerGame.LeftButtonsTurnOFF();
        
        //disable play again button
        _UiManager.DiactivatePlayAgainBytton();
        
        //checking scripts to be attached
        if (playerGame == null)
        {
            Debug.LogError("Put PlayerPlayMode component in the Inspector!");
        }

        if (opponentGame == null)
        {
            Debug.LogError("Put OpponentPlayMode component in the Inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is in the zone - ready to play - activate the Play button
        if (playerSetings.readyToPlay)
        {
            _UiManager.ActivatePlayBytton();
        }
        else
        {
            _UiManager.DiactivatePlayBytton();
        }
        
        //for tests method
        if (Input.GetKeyDown(KeyCode.J))
        {
            RestartTheGameConditions();
        }
        
        //if the player has selected states for the hands, then start the hand animations
        //start the opponent's hand selection
        if (playerGame.leftHandWasChoused && playerGame.rightHandWasChoused)
        {
             Play();
             if (opponentGame.opponentHandWasChoosen == false)
             {
                 opponentGame.GetHandChoise();
             }
             
             //animator for his hands
             opponentGame.RightHandAnimationsON();
             opponentGame.LeftHandAnimationsON();
             //timer for the interval between hand removal selection actions and animations
             if (timer > 0)
             {
                // Debug.Log("TIMER STARTED");
                 timer -= Time.deltaTime;
                 if (timer <= 0)
                 {
                     TimerEnded();
                 }
             }
             else
             {
                 timer = 1.5f;
             }
        }
        //when the right or left hand is selected
        //system can remove the opponent's hand
        //the opponent's hand is removed and a rules check is started
        if (minusRH && needToMinusOpponentFlaf || minusLH && needToMinusOpponentFlaf)
        {
            opponentGame.MinusOpponentHand();
            CheckRulesTest();
            needToMinusOpponentFlaf = false;
            minusLH = false;
            minusRH = false;
            _UiManager.ActivatePlayAgainBytton();
            _UiManager.AvtivateReturnBurron();
            playAgainFlag = true;
            opponentGame.opponentHandWasChoosen = false;
        }
        //if the player pressed the play again button - disable the play again button
        if ( playAgainFlag == false)
        {
            _UiManager.DiactivatePlayAgainBytton(); 
        }
        //if the player left the game area - disable the play again button
        if ( _UiManager.isWalking)
        {
            _UiManager.DiactivatePlayAgainBytton();
        }
    }

    //when the timer ends, it requires you to remove your hand
    private void TimerEnded()
    {
        needToMinusOpponentFlaf = true;
        playerGame.leftHandWasChoused = false;
        playerGame.rightHandWasChoused = false;
        _UiManager.ActivateMinusLeftHandBytton();
        _UiManager.ActivateMinusRightHandBytton();
        _UiManager.ActivateMinusHandText();
    }

    //starts hand animations
    public void Play()
    {
        playerGame.LeftHandAnimatorON();
        playerGame.RightHandAnimatorON();
    }
    

    public void StartThePlay()
    {
        //enable right hand state selection buttons
        playerGame.rightPapperButton.gameObject.SetActive(true);
        playerGame.rightRockButton.gameObject.SetActive(true);
        playerGame.rightScissorsButton.gameObject.SetActive(true);
        //enable left hand state selection buttons
        playerGame.leftRockButton.gameObject.SetActive(true);
        playerGame.leftPapperButton.gameObject.SetActive(true);
        playerGame.leftScissorsButton.gameObject.SetActive(true); 
        //disable start button
        playerSetings.readyToPlay = false;
        _UiManager.DiactivatePlayBytton();
        playerSetings.speadMovement = 0f;
        if (_UiManager.isWalking)
        {
            RestartTheGameConditions();
        }
        _UiManager.isWalking = false;
    }
    

    //Restores all states so the player can play again
    public void RestartTheGameConditions()
    {
        //restart opoonent
        opponentGame.ReturnHand(); 
        opponentGame.systemRightHand = HandState.NoChoise; 
        opponentGame.systemLeftHand = HandState.NoChoise;
        opponentGame.RightHandAnimatiomsOFF();
        opponentGame.LeftHandAnimationsOFF();
        //restart player
        playerGame.RightButtonsTurnOn();
        playerGame.LeftButtonsTurnOn();
        playerGame.playerRightHandChoice = PlayerHandState.NoChouce;
        playerGame.playerLeftHandChoice = PlayerHandState.NoChouce;
        playerGame.LeftHandAnimatorOFF();
        playerGame.RightHandAnimatorOFF();
        playerRightHand.SetActive(true);
        playerLeftHand.SetActive(true);
        _UiManager.DiactivateMinusLeftHandBytton();
        _UiManager.DiactivateMinusRightHandBytton();
        playerGame.leftHandWasChoused = false;
        playerGame.rightHandWasChoused = false;
        //restore replay button
        playAgainFlag = false;
        // deactivate draw
        if (draw)
        {
            _UiManager.DeactivateDrawText();
        }
        _UiManager.returnSpeedButton.gameObject.SetActive(false);
    }

    //method that removes the player's Right hand leaving the left hand remaining
    //turns off the hint about removing the hand
    public void MinusRightHand()
    {
        playerRightHand.SetActive(false);
        playerGame.playerRightHandChoice = PlayerHandState.NoChouce;
        resulTPlay = playerGame.playerLeftHandChoice;
        Debug.Log($"{resulTPlay}");
       
        minusRH = true;
        playerGame.rightHandWasChoused = false;
        playerGame.RightButtonsTurnOFF();
        
        _UiManager.DiactivateMinusLeftHandBytton();
        _UiManager.DiactivateMinusRightHandBytton();
        
        _UiManager.DiactivateMinusHandText();
        opponentGame.MinusOpponentHand();
    }
    
    //method that removes the player's left hand leaving the right hand remaining
    //turns off the hint about removing the hand
    public void MinusLeftHand()
    {
        playerLeftHand.SetActive(false);
        playerGame.playerLeftHandChoice = PlayerHandState.NoChouce;
        resulTPlay = playerGame.playerRightHandChoice;
        Debug.Log($"{resulTPlay}");
        
        minusLH = true;
        playerGame.leftHandWasChoused = false;
        playerGame.LeftButtonsTurnOFF();
        
        _UiManager.DiactivateMinusLeftHandBytton();
        _UiManager.DiactivateMinusRightHandBytton();
        
        _UiManager.DiactivateMinusHandText();
        opponentGame.MinusOpponentHand();
    }

    
    //compares the player's remaining hand with the opponent's remaining hand
    private void CheckRulesTest()
    {
       //player won
        if (resulTPlay == PlayerHandState.Scissors && opponentGame.resultHand == HandState.Paper)
        {
            PlayerWonSituation();
        }
        if (resulTPlay == PlayerHandState.Paper && opponentGame.resultHand == HandState.Rock)
        {
            PlayerWonSituation();
        }
        if (resulTPlay == PlayerHandState.Rock && opponentGame.resultHand == HandState.Scissors)
        {
           PlayerWonSituation(); 
        }
        
       //player lost
       if (resulTPlay == PlayerHandState.Rock && opponentGame.resultHand == HandState.Paper)
       {
           PlayerLostSituation();
       }
       if (resulTPlay == PlayerHandState.Scissors && opponentGame.resultHand == HandState.Rock)
       {
           PlayerLostSituation();
       }
       if (resulTPlay == PlayerHandState.Paper && opponentGame.resultHand == HandState.Scissors)
       {
           PlayerLostSituation();
       }
      //draw
      if (resulTPlay == PlayerHandState.Rock && opponentGame.resultHand == HandState.Rock)
      {
          _UiManager.ActivateDrawText();
          draw = true;
      }
      if (resulTPlay == PlayerHandState.Scissors && opponentGame.resultHand == HandState.Scissors)
      {
          _UiManager.ActivateDrawText();
          draw = true;
      }
      if (resulTPlay == PlayerHandState.Paper && opponentGame.resultHand == HandState.Paper)
      {
          _UiManager.ActivateDrawText();
          draw = true;
      }
        
    }
    
    ////removes coin , changes the score if Player Lost in the game round
    private void PlayerLostSituation()
    {
        scoreManager.DowncreaseScore();
        _OpponentHealthSystem.OpponentSituatuinWon();
    }
    
    //removes coin , changes the score
    private void PlayerWonSituation()
    {
        coinSpawner.DeleteCoin();
        scoreManager.IncreaseScore();
    }
}
