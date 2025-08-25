using UnityEngine;

public enum HandState
{
    NoChoise,
    Rock,
    Paper,
    Scissors
}

public class OpponentPlayMode : MonoBehaviour
{
    public HandState systemLeftHand;
    public HandState systemRightHand;
    public HandState resultHand;

    public bool opponentHandWasChoosen = false;

    public GameObject leftHand;
    public GameObject rightHand;

    public Animator opponentLeftHandAnimator;
    public Animator opponentRightHandanimator;

    public int numberOfLifes = 3;
    
    // system get random number and this way choose hand state
    public void GetHandChoise()
    {
        int leftChoice = UnityEngine.Random.Range(1, 4);
        systemLeftHand = (HandState)leftChoice;
        Debug.Log($"Opponent Left hand {systemLeftHand}");

        int rightChoice = UnityEngine.Random.Range(1, 4);
        systemRightHand = (HandState)rightChoice;
        Debug.Log($"Opponent Right hand {systemRightHand}");

        opponentHandWasChoosen = true;
    }
    
    //method take random number and this way remove random hand and make second hand = result hand to compare rules
    public void MinusOpponentHand()
    {
        
        int randomNum = UnityEngine.Random.Range(0, 2);

        
        if (randomNum == 0)
        {
            leftHand.SetActive(false);
            rightHand.SetActive(true);
            resultHand = systemRightHand;  
           // Debug.Log($"{resultHand}");
        }
       
        if (randomNum == 1)
        {
            rightHand.SetActive(false);
            leftHand.SetActive(true);
            resultHand = systemLeftHand;  
            //Debug.Log($"{resultHand}");
        }
    }
    
    // reactivate hands
    public void ReturnHand()
    {
        rightHand.SetActive(true);
        leftHand.SetActive(true);
    }

    //turns left hand animation On 
    public void LeftHandAnimationsON()
    {
        if (systemLeftHand == HandState.Rock)
        {
            opponentLeftHandAnimator.SetBool("leftIsRock", true);    
        }
        else if (systemLeftHand == HandState.Paper)
        {   
            opponentLeftHandAnimator.SetBool("leftIsPapper", true);
        }
        else if (systemLeftHand == HandState.Scissors)
        {   
            opponentLeftHandAnimator.SetBool("leftIsScissors", true);
        }
    }

    //turns hands animation Off
    public void LeftHandAnimationsOFF()
    {
        if (systemLeftHand == HandState.NoChoise)
        {
            opponentLeftHandAnimator.SetBool("leftIsScissors", false);
            opponentLeftHandAnimator.SetBool("leftIsPapper", false);
            opponentLeftHandAnimator.SetBool("leftIsRock", false); 
        }
    }
    
    
    //turns right hand animation On 
    public void RightHandAnimationsON()
    {
        if (systemRightHand == HandState.Rock)
        {
            opponentRightHandanimator.SetBool("rightIsRock", true);    
        }
        else if (systemRightHand == HandState.Paper)
        {   
            opponentRightHandanimator.SetBool("rightIsPapper", true);
        }
        else if (systemRightHand == HandState.Scissors)
        {   
            opponentRightHandanimator.SetBool("rightIsScissors", true);
        }
    }
    //turns right hand animation Off
    public void RightHandAnimatiomsOFF()
    {
        if (systemRightHand == HandState.NoChoise)
        {
            opponentRightHandanimator.SetBool("rightIsScissors", false);
            opponentRightHandanimator.SetBool("rightIsRock", false);
            opponentRightHandanimator.SetBool("rightIsPapper", false); 
        }
    }
    
    
    
    
    
    //for test method
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GetHandChoise();
        } 
    }
}
