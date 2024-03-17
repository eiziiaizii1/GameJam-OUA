using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [SerializeField] private AudioSource 
        EffectSource, 
        RunSource, 
        BackgroundMusicSource;

    [SerializeField] private AudioClip laserSoundEffect;
    [SerializeField] private AudioClip smashSound;
    [SerializeField] private AudioClip doorSound;
    [SerializeField] private AudioClip enemySpawnSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip playerHurtSound;
    [SerializeField] private AudioClip baseDamageSound;
    [SerializeField] private AudioClip dyingPlayerSound;
    [SerializeField] private AudioClip dyingEnemySound;
    [SerializeField] private AudioClip enemyHurtSound;
    [SerializeField] private AudioClip platethrowSound;

    public AudioClip LaserSoundEffect { get => laserSoundEffect; set => laserSoundEffect = value; }
    public AudioClip SmashSound { get => smashSound; set => smashSound = value; }
    public AudioClip DoorSound { get => doorSound; set => doorSound = value; }
    public AudioClip EnemySpawnSound { get => enemySpawnSound; set => enemySpawnSound = value; }
    public AudioClip GameOverSound { get => gameOverSound; set => gameOverSound = value; }
    public AudioClip PlayerHurtSound { get => playerHurtSound; set => playerHurtSound = value; }
    public AudioClip BaseDamageSound { get => baseDamageSound; set => baseDamageSound = value; }
    public AudioClip DyingPlayerSound { get => dyingPlayerSound; set => dyingPlayerSound = value; }
    public AudioClip DyingEnemySound { get => dyingEnemySound; set => dyingEnemySound = value; }
    public AudioClip EnemyHurtSound { get => enemyHurtSound; set => enemyHurtSound = value; }
    public AudioClip PlatethrowSound { get => platethrowSound; set => platethrowSound = value; }


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

    private void Start()
    {
        BackgroundMusicSource.Play();
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

    public void PlayEffectSound(AudioClip clipToPlay, float effectVolume)
    {
        //if (EffectSource.isPlaying) return;

        EffectSource.PlayOneShot(clipToPlay);

        EffectSource.volume = effectVolume;

        EffectSource.PlayOneShot(clipToPlay);
    }
}