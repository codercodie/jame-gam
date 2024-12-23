using UnityEngine;
using UnityEngine.UI;

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
        speedController=GameObject.Find("SpeedController").GetComponent<SpeedController>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        if (speedSlider != null)
        {
            if (selectedSpeed != 0f)
            {
                speedSlider.value = selectedSpeed;
            }
            else
            {
                speedSlider.value = 2f;
            }

            speedSlider.onValueChanged.AddListener(OnNumberSliderValueChanged);
            OnNumberSliderValueChanged(speedSlider.value);
        }

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
        // Invert the value
        musicVolume = 1.0f - value;
        Debug.Log("Music Volume: " + musicVolume);
        audioManager.SetMusicVolume(musicVolume);
    }

    private void OnSFXVolumeSliderValueChanged(float value)
    {
        // Invert the value
        sfxVolume = 1.0f - value;
        Debug.Log("SFX Volume: " + sfxVolume);
        audioManager.SetSFXVolume(sfxVolume);
    }

    private void OnNumberSliderValueChanged(float value)
    {
        // Invert the value
        value = 1.0f - Mathf.Clamp(value, speedSlider.minValue, speedSlider.maxValue);
        selectedSpeed = value;
        SetCameraSpeed(selectedSpeed);
        Debug.Log("Selected Speed: " + selectedSpeed);
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
