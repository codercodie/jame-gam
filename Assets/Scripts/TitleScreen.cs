using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public GameObject tutorialPopup, settingsPanel, credits;
    public AudioManager audioManager;
    public GameObject intro;

    // Start is called before the first frame update
    void Start()
    {
        tutorialPopup.SetActive(false);
        settingsPanel.SetActive(false);
        intro.SetActive(false);
        credits.SetActive(false);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.PlayMusic(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (credits.activeSelf && Input.GetKeyDown(KeyCode.Escape)) {
            HideCredits();
            audioManager.PlayMusic(1);
        }
    }

    public void ShowIntro()
    {
        intro.SetActive(true);
        Debug.Log("Attempting to play music track 2");
        audioManager.PlayMusic(2);
    }

    public void ShowTutorialPopup()
    {
        tutorialPopup.SetActive(true);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LaunchTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void HideTutorialPopup()
    {
        tutorialPopup.SetActive(false);
    }

    public void HideSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
        audioManager.PlayMusic(5);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
    }




}
