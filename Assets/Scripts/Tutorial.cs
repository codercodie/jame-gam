using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    public CameraController cameraController;
    public GameObject instructions1;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "TitleScreen")
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                pauseGame();
            }
        }

        if (cameraController.startMoving)
        {
            instructions1.SetActive(false);
        }
    }

    public void TutorialComplete()
    {
        Debug.Log("Tutorial Complete!");
        Time.timeScale = 0;
        audioManager.PlaySFX(0);
    }

    public void pauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void loadSettings()
    {
        settingsScreen.SetActive(true);
    }

    public void closeSettings()
    {
        settingsScreen.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }


}
