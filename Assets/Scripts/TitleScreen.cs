using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public GameObject tutorialPopup, settingsPanel;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        tutorialPopup.SetActive(false);
        settingsPanel.SetActive(false);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.PlayMusic(1);
    }

    // Update is called once per frame
    void Update()
    {
        
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




}
