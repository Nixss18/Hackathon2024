using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.instance.drinkCount);
        //launch event from here 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bottle")
        {

            Debug.Log("Drank something");
            GameManager.instance.drinkCount += 1;
        }
    }
}
