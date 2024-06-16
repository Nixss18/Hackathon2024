using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerController : MonoBehaviour
{

public XRBaseController leftcontroller;

//public GameObject CoastObjects;


private float movementSpeed;
// Distance of the back and forth movement
//private float maxDistance = 10f;

private Vector3 startPosition;
private float defaultSpeed = 0.045f;
 

// void Start()
// {
//     // Store the initial position of the object
//     startPosition = CoastObjects.transform.position;
//     movementSpeed = defaultSpeed;
    
// }
// private void Update() 
// {
//      //leftcontroller.SendHapticImpulse(0.5f, 0.5f);    
     
//     //float currentPosition = Mathf.PingPong(Time.time * speed, distance);
//     CoastObjects.transform.position += Vector3.right * movementSpeed * Time.deltaTime;
//     if (Vector3.Distance(startPosition, CoastObjects.transform.position) >= maxDistance)
//     {
//         // Reset the object's position to the starting position
//         CoastObjects.transform.position = startPosition;
//     }

    
// }

    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.tag == "Water")
        {
            Debug.Log("Cube touched by the Player!");
            // OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            leftcontroller.SendHapticImpulse(0.5f, 0.5f);
            movementSpeed = 0.09f;
        }
      
        
    }

    private void OnTriggerExit(Collider other)
    {
        movementSpeed = defaultSpeed;    
    }


//    
//     }
 }
