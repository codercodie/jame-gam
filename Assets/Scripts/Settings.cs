using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public SpeedController speedController;

    public Slider speedSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private float selectedSpeed;
    private float musicVolume;
    private float sfxVolume;

    public AudioManager audioManager;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "TitleScreen")
        {
            // Set the slider range to 0 to 3
            speedSlider.minValue = 0f;
            speedSlider.maxValue = 3f;

            // Reference to SpeedController and AudioManager
            speedController = GameObject.Find("SpeedController").GetComponent<SpeedController>();
            // Set the initial speed slider value to the current speed from SpeedController
            speedSlider.value = 3f - speedController.speed; // Inverted mapping

            // Apply the initial value of the slider immediately
            OnNumberSliderValueChanged(speedSlider.value);

            // Listen for changes in the slider
            if (speedSlider != null)
            {
                speedSlider.onValueChanged.AddListener(OnNumberSliderValueChanged);
            }
        }


        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();


        // Set initial music and SFX volume
        if (musicVolumeSlider != null)
        {
            musicVolume = audioManager.musicVolume;
            musicVolumeSlider.value = musicVolume;
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderValueChanged);
            OnMusicVolumeSliderValueChanged(musicVolumeSlider.value);
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolume = audioManager.sfxVolume;
            sfxVolumeSlider.value = sfxVolume;
            sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeSliderValueChanged);
            OnSFXVolumeSliderValueChanged(sfxVolumeSlider.value);
        }
    }

    private void OnMusicVolumeSliderValueChanged(float value)
    {
        musicVolume = 1.0f - value;
        Debug.Log("Music Volume: " + musicVolume);
        audioManager.SetMusicVolume(musicVolume);
    }

    private void OnSFXVolumeSliderValueChanged(float value)
    {
        sfxVolume = 1.0f - value;
        Debug.Log("SFX Volume: " + sfxVolume);
        audioManager.SetSFXVolume(sfxVolume);
    }

    private void OnNumberSliderValueChanged(float value)
    {
        // Invert the slider value: 
        // 0 -> Speed 3, 1 -> Speed 2, 2 -> Speed 1, 3 -> Speed 0
        selectedSpeed = 3f - value;
        Debug.Log("Slider Value Changed: " + value + " -> Selected Speed: " + selectedSpeed);

        // Update the speed in the SpeedController
        SetCameraSpeed(selectedSpeed);
    }

    public void SFXrelease()
    {
        audioManager.PlaySFX(10);
    }

    // Example getter methods for the slider values
    public float GetSelectedNumber()
    {
        return selectedSpeed;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public void SetCameraSpeed(float speed)
    {
        speedController.SetSpeed(speed);
    }

    public void SetMusicVolume(float vol)
    {
        //
    }

    public void SetSFXvolume(float vol)
    {
        //
    }
}
