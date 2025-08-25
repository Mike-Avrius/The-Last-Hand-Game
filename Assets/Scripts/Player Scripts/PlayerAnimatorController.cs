using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    
    public Animator _PlayerAnimator;
    public bool creditsPlay;
    
    //Method that activates Player Lose animation
    public void PlayerLostAnimation()
    {
        _PlayerAnimator.SetTrigger("isLosing");
        //Debug.Log($"Player Lost!");
    }
    
    //Method that activats Credits play - use through Trigger event in animation
    public void MakeCreditsPlay()
    {
        creditsPlay = true;
    }
    
}
