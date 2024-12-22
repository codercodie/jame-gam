using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameCompleteScreen;
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    public TextMeshProUGUI gameOverGifts;
    public TextMeshProUGUI gameCompleteGifts;
    public GiftCounter giftCounter;
    public int totalHouses;

    private void Start()
    {
        Time.timeScale = 1;
        SetPanelsInactive();

        totalHouses = 0;
        GameObject[] houses = GameObject.FindGameObjectsWithTag("house");
        Debug.Log("Houses Found: " + houses.Length);
        foreach (GameObject house in houses)
        {
            totalHouses++;
        }
        Debug.Log("Total Houses: " + totalHouses);

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "TitleScreen")
        {
            if (Input.GetKeyDown(KeyCode.Escape)  || Input.GetKeyDown(KeyCode.P))
            {
                pauseGame();
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Debug.Log("Gifts Delivered: " + giftCounter.giftsDelivered);
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        gameOverGifts.text = giftCounter.giftsDelivered.ToString() + "/" + totalHouses.ToString();
    }

    public void GameComplete()
    {
        Debug.Log("Game Complete!");
        Debug.Log("Gifts Delivered: " + giftCounter.giftsDelivered);
        Time.timeScale = 0;
        gameCompleteScreen.SetActive(true);
        gameCompleteGifts.text = giftCounter.giftsDelivered.ToString() + "/" + totalHouses.ToString();
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

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
        SetPanelsInactive();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void SetPanelsInactive()
    {
        GameObject[] totalPanels = GameObject.FindGameObjectsWithTag("Panel");
        foreach (GameObject panel in totalPanels)
        {
            panel.SetActive(false);
        }

    }

}
