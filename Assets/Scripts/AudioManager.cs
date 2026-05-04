using UnityEngine;

public class AudioManagerù : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioClip backgroundMusic;

    void Start()
    {
       backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.time = 0;
        backgroundMusicSource.Play();
    }
}
