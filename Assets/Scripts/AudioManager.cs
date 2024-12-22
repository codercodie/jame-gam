using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton for global access

    public AudioSource musicSource; // For background music

    [Range(0f, 1f)] public float musicVolume = 1f; // Default music volume
    [Range(0f, 1f)] public float sfxVolume = 1f; // Default SFX volume

    public AudioClip[] musicClips; // Array for music clips
    public AudioClip[] sfxClips;   // Array for SFX clips

    private void Awake()
    {
        // Singleton pattern to ensure only one AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Set the volume for music
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
    }

    // Set the volume for SFX
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
    }

    // Play a music track by index
    public void PlayMusic(int clipIndex)
    {
        if (musicSource != null && musicClips != null && clipIndex >= 0 && clipIndex < musicClips.Length)
        {
            musicSource.clip = musicClips[clipIndex];
            musicSource.volume = musicVolume;
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.LogError("Invalid music clip index or no clips available.");
        }
    }

    // Play a sound effect by index
    public void PlaySFX(int clipIndex)
    {
        if (sfxClips != null && clipIndex >= 0 && clipIndex < sfxClips.Length)
        {
            // Create a new AudioSource dynamically for each SFX
            AudioSource sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.clip = sfxClips[clipIndex];
            sfxSource.volume = sfxVolume;
            sfxSource.Play();

            // Destroy the AudioSource after the clip has finished playing
            Destroy(sfxSource, sfxClips[clipIndex].length);
        }
        else
        {
            Debug.LogError("Invalid SFX clip index or no clips available.");
        }
    }
}
