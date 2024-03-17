using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [SerializeField] private AudioSource EffectSource, RunSource, BackgroundMusicSource;

    [SerializeField] private AudioClip laserSoundEffect;
    [SerializeField] private AudioClip smashSound;
    [SerializeField] private AudioClip doorSound;
    [SerializeField] private AudioClip enemySpawnSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip playerHurtSound;

    public AudioClip LaserSoundEffect { get => laserSoundEffect; set => laserSoundEffect = value; }
    public AudioClip SmashSound { get => smashSound; set => smashSound = value; }
    public AudioClip DoorSound { get => doorSound; set => doorSound = value; }
    public AudioClip EnemySpawnSound { get => enemySpawnSound; set => enemySpawnSound = value; }
    public AudioClip GameOverSound { get => gameOverSound; set => gameOverSound = value; }
    public AudioClip PlayerHurtSound { get => playerHurtSound; set => playerHurtSound = value; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RunSound()
    {
        RunSource.Play();
    }
    public void StopRunSound()
    {
        RunSource.Stop();
    }

    public void PlayBackgroundSound()
    {
        BackgroundMusicSource.Play();
    }
    public void StopBackgroundSound()
    {
        BackgroundMusicSource.Stop();
    }

    public void StopEffectSounds()
    {
        BackgroundMusicSource.Stop();
    }

    public void PlayEffectSound(AudioClip clipToPlay)
    {
        //if (EffectSource.isPlaying) return;

        EffectSource.PlayOneShot(clipToPlay);
    }
}