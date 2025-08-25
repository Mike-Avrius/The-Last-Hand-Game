using UnityEngine;

public class LampMusicController : MonoBehaviour
{
    public AudioSource[] lampSoundSource;     

    //methods activate sounds of turning on pairs of lamps
    
    public void ForFirstLampsMusicActivation()
    {
        lampSoundSource[0].Play();
        lampSoundSource[1].Play();
    }
    public void ForSecondLampsMusicActivation()
    {
        lampSoundSource[2].Play();
        lampSoundSource[3].Play();
    }
    public void ForThirdLampsMusicActivation()
    {
        lampSoundSource[4].Play();
        lampSoundSource[5].Play();
    }
}
