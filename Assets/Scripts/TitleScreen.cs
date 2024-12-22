using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public GameObject tutorialPopup;

    // Start is called before the first frame update
    void Start()
    {
        tutorialPopup.SetActive(false);
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
        // show setings popup here
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

    public void hideTutorialPopup()
    {
        tutorialPopup.SetActive(false);
    }



}
