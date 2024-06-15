using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingController : MonoBehaviour
{
    // [SerializeField] private AudioSource soundSrc;
    [SerializeField] float delayTime = 10f;
    private bool didDrink = false;
    private float timer = 0.0f;

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
