using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingController : MonoBehaviour
{
    // [SerializeField] private AudioSource soundSrc;
    [SerializeField] float delayTime = 10f;
    [SerializeField] GameObject audioSrc;

    public GameObject DuckWithTressure;
    public GameObject Demon;
    private bool didDrink = false;
    private float timer = 0.0f;
    private bool event1Happened = false;
    private bool event2Happened = false;
    private bool event3Happened = false;
    private bool event4Happened = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.instance.drinkCount);
        if (timer > delayTime)
        {
            if (didDrink)
            {
                didDrink = false;
                timer = 0.0f;
            }
        }

        if (timer <= delayTime)
        {
            timer += Time.deltaTime;
        }

        // if (GameManager.instance.drinkCount == 3)
        // {
        //     audioSrc.SetActive(true);
        //     audioSrc.GetComponent<AudioSource>().Play();
        //     Demon.SetActive(true);
        // }
        // if (GameManager.instance.drinkCount == 4)
        // {
        //     audioSrc.SetActive(true);
        //     audioSrc.GetComponent<AudioSource>().Play();
        //     DuckWithTressure.SetActive(true);
        // }
        drinkingEvents();
    }

    void drinkingEvents()
    {
        switch (GameManager.instance.drinkCount)
        {
            case 1:
                Debug.Log("Event 1");

                break;
            case 2:
                Debug.Log("Event 2");

                break;
            case 3:
                if (!event3Happened)
                {
                    event3Happened = true;
                    if (!GameManager.instance.eventHappening)
                    {
                        audioSrc.SetActive(true);
                        Demon.SetActive(true);
                        GameManager.instance.eventHappening = true;


                    }
                }
                // audioSrc.GetComponent<AudioSource>().Play();
                break;
            case 4:
                if (!event4Happened)
                {
                    event3Happened = true;
                    if (!GameManager.instance.eventHappening)
                    {
                        audioSrc.SetActive(true);
                        audioSrc.GetComponent<AudioSource>().Play();
                        DuckWithTressure.SetActive(true);
                        GameManager.instance.eventHappening = true;
                    }
                }
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bottle")
        {
            if (!didDrink)
            {
                Debug.Log("Drank something");
                GetComponent<AudioSource>().Play();
                GameManager.instance.drinkCount += 1;
                didDrink = true;
            }
        }
    }
}
