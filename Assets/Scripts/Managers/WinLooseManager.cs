using UnityEngine;

public class WinLooseManager : MonoBehaviour
{
    
    public CoinsSpawner coinSpawner;
    public Animator _LampAnimator;
    public UiManager _UiManager;
    public LampAnimationTrigger _LampAnimationTrigger;
    public PlayerAnimatorController _PlayerAnimator;

   
   
    // checks if there are 8 coins in the hidden coins list then the player has won ,
    //if 0 then the player lost
    void Update()
    {
        if (coinSpawner.hidenCoins.Count == 8)
        {
           PlayerWon();
        }
        else if (coinSpawner.hidenCoins.Count == 0)
        {
            PlayerLost();
        }
    }


    //disables the buttons that allow you to play again
    //enables the Victory Animation
    //starts the credits
    public void PlayerWon()
    {
        _UiManager.DeacrivateReplayabilityButtons();
        _LampAnimator.SetTrigger("IsFalling");
        if (_LampAnimationTrigger.creditsPlay)
        {
            _UiManager.PlayCredits();
        }

        
        Debug.Log($"Player WON!");
    }
    
    //disables the buttons that allow you to play again
    //enables the Lossing Animation
    //starts the credits
    public void PlayerLost()
    { 
        _UiManager.DeacrivateReplayabilityButtons();
        _PlayerAnimator.PlayerLostAnimation();
       if (_PlayerAnimator.creditsPlay)
       {
           _UiManager.PlayCredits();
       }
    }
}
