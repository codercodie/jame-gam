using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftDelivered : MonoBehaviour
{
    public DropGift dropGift;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.name);

        // Use tag-based detection (ensure you tagged "CountGift" correctly in the Inspector)
        if (collision.CompareTag("delivered"))
        {
            Debug.Log("Gift Delivered!");
            dropGift.delivered = true;
        }
    }
}
