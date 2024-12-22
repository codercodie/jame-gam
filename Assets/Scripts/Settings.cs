using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public SpeedController speedController;

    public Slider speedSlider; 
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private float selectedSpeed;
    private float musicVolume;
    private float sfxVolume;

    void Start()
    {
        speedController=GameObject.Find("SpeedController").GetComponent<SpeedController>();

        if (speedSlider != null)
        {
            speedSlider.onValueChanged.AddListener(OnNumberSliderValueChanged);
            OnNumberSliderValueChanged(speedSlider.value);
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderValueChanged);
            OnMusicVolumeSliderValueChanged(musicVolumeSlider.value);
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeSliderValueChanged);
            OnSFXVolumeSliderValueChanged(sfxVolumeSlider.value);
        }
    }

    private void OnNumberSliderValueChanged(float value)
    {
        value = Mathf.Clamp(value, speedSlider.minValue, speedSlider.maxValue);
        selectedSpeed = value;
        SetCameraSpeed(selectedSpeed);
        Debug.Log("Selected Speed: " + selectedSpeed);
    }

    private void OnMusicVolumeSliderValueChanged(float value)
    {
        musicVolume = value;
        Debug.Log("Music Volume: " + musicVolume);
    }

    private void OnSFXVolumeSliderValueChanged(float value)
    {
        sfxVolume = value;
        Debug.Log("SFX Volume: " + sfxVolume);
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
