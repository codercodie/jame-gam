using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    public Image flagImage;
    public Sprite ausFlag, chinaFlag, indiaFlag;

    private void Start()
    {
        if (flagImage == null)
        {
            Debug.LogError("Flag Image is not assigned!");
            return;
        }

        flagImage.sprite = ausFlag; // first location
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "australia":
                flagImage.sprite = ausFlag;
                Debug.Log("Australia flag set");
                break;
            case "china":
                flagImage.sprite = chinaFlag;
                Debug.Log("China flag set");
                break;

            case "india":
                flagImage.sprite = indiaFlag;
                Debug.Log("India flag set");
                break;

            default:
                // do not change location if the item is not a location trigger!
                break;
        }
    }
}
