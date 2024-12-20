using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DropGift : MonoBehaviour
{
    public GameObject giftGO;
    public SpriteRenderer gift;
    public Sprite purple, green, pink, orange, yellow;
    public float moveSpeed = 5f;
    public int drops;

    private bool playerInTrigger;
    public bool delivered;
    private bool isMoving;

    public GameManager manager;
    public GiftCounter giftCounter;

    private void Start()
    {
        drops = 0;
        playerInTrigger = false;
        delivered = false;
        isMoving = false;
    }

    private void Update()
    {
        // Check for player input when the player is inside the trigger area
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E) && drops == 0)
        {
            DropTheGift();
        }

        if (isMoving)
        {
            giftGO.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            if (delivered)
            {
                isMoving = false;
                Destroy(giftGO);
                if (giftCounter != null)
                {
                    giftCounter.GiftDelivered();
                }
            }
        }
    }

    public void OnTriggerEnter2D (Collider2D coll)
    {

        if (coll.CompareTag("Player"))
        {
            Debug.Log("Player detected on chimney");
            playerInTrigger = true; // Set flag to true when the player enters the trigger
        }
    }
    public void DropTheGift()
    {
        Debug.Log("Dropping Gift!");
        giftGO.SetActive(true);
        drops = 1;
        gift = giftGO.GetComponent<SpriteRenderer>();
        // Randomly select a gift sprite
        int r = UnityEngine.Random.Range(0, 5);
        switch (r)
        {
            case 0:
                gift.sprite = purple;
                break;
            case 1:
                gift.sprite = green;
                break;
            case 2:
                gift.sprite = pink;
                break;
            case 3:
                gift.sprite = orange;
                break;
            case 4:
                gift.sprite = yellow;
                break;
        }

        // Set the flag to start moving the gift
        isMoving = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger area");
            playerInTrigger = false; // Reset flag when the player leaves the trigger
        }
    }
}
