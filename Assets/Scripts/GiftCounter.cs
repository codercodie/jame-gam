using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiftCounter : MonoBehaviour
{

    public TextMeshProUGUI giftCounter;
    public int giftsDelivered;


    // Start is called before the first frame update
    void Start()
    {
        giftsDelivered = 0;
        giftCounter.text = giftsDelivered.ToString();

    }

    public void GiftDelivered()
    {
        giftsDelivered++;
        giftCounter.text = giftsDelivered.ToString();

    }


}
