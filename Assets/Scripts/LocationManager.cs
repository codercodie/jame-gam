using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    public TextMeshProUGUI location;
    //public Image flagImage;
    //public Sprite ausFlag, chinaFlag, indiaFlag, uaeFlag, germanyFlag, franceFlag, italyFlag, ukFlag, finlandFlag, egyptFlag, usaFlag;

    //private void Start()
    //{
    //    if (flagImage == null)
    //    {
    //        Debug.LogError("Flag Image is not assigned!");
    //        return;
    //    }

    //    flagImage.sprite = ausFlag; // first location
    //}

    private void Start()
    {

        location.text = "Training Grounds"; // starts empty
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "australia":
                location.text = "Australia";
                break;
            case "china":
                location.text = "China";
                break;
            case "india":
                location.text = "India";
                break;
            case "uae":
                location.text = "UAE";
                break;
            case "germany":
                location.text = "Germany";
                break;
            case "france":
                location.text = "France";
                break;
            case "italy":
                location.text = "Italy";
                break;
            case "uk":
                location.text = "United Kingdom";
                break;
            case "finland":
                location.text = "Finland";
                break;
            case "egypt":
                location.text = "Egypt";
                break;
            case "usa":
                location.text = "USA";
                break;
            default:
        // do not change location if the item is not a location trigger!
              break;
        }   
    
    }


        //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    switch (collision.tag)
    //    {
    //        case "australia":
    //            flagImage.sprite = ausFlag;
    //            Debug.Log("Australia flag set");
    //            break;
    //        case "china":
    //            flagImage.sprite = chinaFlag;
    //            Debug.Log("China flag set");
    //            break;
    //        case "india":
    //            flagImage.sprite = indiaFlag;
    //            Debug.Log("India flag set");
    //            break;
    //        case "uae":
    //            flagImage.sprite = uaeFlag;
    //            Debug.Log("UAE flag set");
    //            break;
    //        case "germany":
    //            flagImage.sprite = germanyFlag;
    //            Debug.Log("Germany flag set");
    //            break;
    //        case "france":
    //            flagImage.sprite = franceFlag;
    //            Debug.Log("France flag set");
    //            break;
    //        case "italy":
    //            flagImage.sprite = italyFlag;
    //            Debug.Log("Italy flag set");
    //            break;
    //        case "uk":
    //            flagImage.sprite = ukFlag;
    //            Debug.Log("UK flag set");
    //            break;
    //        case "finland":
    //            flagImage.sprite = finlandFlag;
    //            Debug.Log("Finland flag set");
    //            break;
    //        case "egypt":
    //            flagImage.sprite = egyptFlag;
    //            Debug.Log("Egypt flag set");
    //            break;
    //        case "usa":
    //            flagImage.sprite = usaFlag;
    //            Debug.Log("USA flag set");
    //            break;

    //        default:
    //            // do not change location if the item is not a location trigger!
    //            break;
    //    }
    //}
}
