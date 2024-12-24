using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionScene : MonoBehaviour
{

    public GameObject Scene1, Scene2, Scene3, Scene4, tutorialPopup;
    public int currentIntroScene;

    // Start is called before the first frame update
    void Start()
    {
        SetAllInactive();
        LaunchIntro();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // skip intro
        {
            ShowTutorialPopup();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentIntroScene)
            {
                case 1:
                    LaunchScene2();
                    break;
                case 2:
                    LaunchScene3();
                    break;
                case 3:
                    LaunchScene4();
                    break;
                case 4:
                    ShowTutorialPopup();
                    break;
            }
        }
    }

    public void LaunchIntro()
    {
        Scene1.SetActive(true);
        currentIntroScene = 1;

    }

    public void LaunchScene2()
    {
        Scene2.SetActive(true);
        Scene1.SetActive(false);
        currentIntroScene = 2;
    }

    public void LaunchScene3()
    {
        Scene3.SetActive(true);
        Scene2.SetActive(false);
        currentIntroScene = 3;
    }

    public void LaunchScene4()
    {
        Scene4.SetActive(true);
        Scene3.SetActive(false);
        currentIntroScene = 4;
    }

    public void SetAllInactive()
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    public void ShowTutorialPopup()
    {
        Scene4.SetActive(false);
        tutorialPopup.SetActive(true);
    }



}
