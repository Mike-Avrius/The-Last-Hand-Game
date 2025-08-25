using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody rb;
    public float speadMovement = 10f;
    
    //bool var for checkig if player CAN or CANNOT play
    public bool readyToPlay = false;
    
    //link to LevelHandsManager script
    public LevelHandsManager _LevelHandsManager;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   //cause of rigidbody i used FixedUpdate for checking movement
    void FixedUpdate()
    {
        Movement(speadMovement);
    }
    
    //Checking if player entered trigger zone
    private void OnTriggerEnter(Collider other)
    {
        //make player ready to play
        if (other.CompareTag("Opponent"))
        {
            readyToPlay = true;
            //Debug.Log("Touched:" + other.gameObject.name);
        }
        //activate Lamp animations
        if (other.CompareTag("HandCollider"))
        {
            _LevelHandsManager.ActivateHandLamp();  
            other.gameObject.SetActive(false); 
        }
    }
    
    //Checking if player exit the trigger zone so he couldnot play
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Opponent"))
        {
            readyToPlay = false;
        }
        //Debug.Log("Touched:" + other.gameObject.name);
    }
    
    
    //player movement method - check for users input and change direction
    //then use rb.linearVelocity to move player
    private void Movement(float speed)
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        Vector3 localMovement = transform.TransformDirection(moveDirection);
        rb.linearVelocity = localMovement * speadMovement;
    }

    //make player stop moving
    public void StopMoving()
    {
        speadMovement = 0f;
    }
}
