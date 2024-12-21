using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameCompleteScreen;
    public TextMeshProUGUI gameOverGifts;
    public TextMeshProUGUI gameCompleteGifts;
    public GiftCounter giftCounter;
    public int totalHouses;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        gameCompleteScreen.SetActive(false);
        totalHouses = 0;
        GameObject[] houses = GameObject.FindGameObjectsWithTag("house");
        Debug.Log("Houses Found: " + houses.Length);
        foreach (GameObject house in houses)
        {
            totalHouses++;
        }
        Debug.Log("Total Houses: " + totalHouses);

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

}
