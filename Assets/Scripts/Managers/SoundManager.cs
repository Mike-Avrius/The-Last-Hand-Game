using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusicSource;  // Фоновая музыка
    
    //methods activate music in the background
    void Start()
    {
        backgroundMusicSource.Play();
    }
}
