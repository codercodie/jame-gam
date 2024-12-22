using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton for global access

    public AudioSource musicSource; // For background music
    public List<AudioSource> activeSFXSources = new List<AudioSource>(); // Track active SFX

    [Range(0f, 1f)] public float musicVolume = 0.5f; // Default music volume
    [Range(0f, 1f)] public float sfxVolume = 0.5f; // Default SFX volume

    public AudioClip[] musicClips; // Array for music clips
    public AudioClip[] sfxClips;   // Array for SFX clips

    private void Awake()
    {
        // Singleton pattern
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
        // Update all active SFX sources
        foreach (var sfxSource in activeSFXSources)
        {
            if (sfxSource != null)
            {
                sfxSource.volume = sfxVolume;
            }
        }
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

            // Add to active sources list
            activeSFXSources.Add(sfxSource);

            // Remove from active sources list after it finishes playing
            StartCoroutine(RemoveSourceAfterPlay(sfxSource));
        }
        else
        {
            Debug.LogError("Invalid SFX clip index or no clips available.");
        }
    }

    // Remove the AudioSource from the list after playback
    private IEnumerator RemoveSourceAfterPlay(AudioSource sfxSource)
    {
        yield return new WaitForSeconds(sfxSource.clip.length);
        activeSFXSources.Remove(sfxSource);
        Destroy(sfxSource);
    }
}
