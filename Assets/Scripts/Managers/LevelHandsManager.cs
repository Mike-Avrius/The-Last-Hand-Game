using System;
using UnityEngine;

public class LevelHandsManager : MonoBehaviour
{
    public GameObject rockLamps;
    public GameObject paperLamps;
    public GameObject scissorsLamps;
    public LampMusicController _LampMusicController;

    private bool rockLampIsActivated;
    private bool papperHLampIsActivated;
    private bool scissorsLampIsActivated;
    
    
    // disables the parent object each of which has 2 child objects lamps
    void Start()
    {
        rockLamps.SetActive(false);
        paperLamps.SetActive(false);
        scissorsLamps.SetActive(false);
    }

    // depending on which pair is already activated - activates the lamps - used in the player script
    public void ActivateHandLamp()
    {
        if (rockLampIsActivated == false)
        {
            rockLamps.SetActive(true);
            rockLampIsActivated = true;
            _LampMusicController.ForFirstLampsMusicActivation();
        }
        else if (papperHLampIsActivated == false)
        {
            paperLamps.SetActive(true);
            papperHLampIsActivated = true;
            _LampMusicController.ForSecondLampsMusicActivation();
        }
        else if (scissorsLampIsActivated == false)
        {
            scissorsLamps.SetActive(true);
            scissorsLampIsActivated = true;
            _LampMusicController.ForThirdLampsMusicActivation();
        }
    }

}
