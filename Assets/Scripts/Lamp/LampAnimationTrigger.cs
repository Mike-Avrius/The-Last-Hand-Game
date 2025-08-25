using UnityEngine;

public class LampAnimationTrigger : MonoBehaviour
{
    public bool opponentToGo;
    public bool creditsPlay;
    
    // method that makes flag true to activate animation of opponent's disappearance via opponent health script
    public void MakeOpponentGo()
    {
        opponentToGo = true;
    }
    
    // method that makes flag true to activate animation of Credits's appearance via Credits script
    public void MakeCreditsPlay()
    {
        creditsPlay = true;
    }
}
