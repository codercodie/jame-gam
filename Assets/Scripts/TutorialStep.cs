using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialStep : MonoBehaviour
{
    public GameObject previousInstructions, nextInstructions;
    public bool stepPause;

    // Start is called before the first frame update
    void Start()
    {
        nextInstructions.SetActive(false);
        stepPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stepPause && Input.anyKeyDown){
            Continue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){ 
            previousInstructions.SetActive(false);
            nextInstructions.SetActive(true);
            Time.timeScale = 0;
            stepPause = true;
        }
    }

    private void Continue()
    {
        Time.timeScale = 1;
        stepPause = false;
        Destroy(gameObject);
    }

    
}
