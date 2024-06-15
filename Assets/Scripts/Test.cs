using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Test : MonoBehaviour
{

public XRBaseController leftcontroller;


private void Update() 
{
     //leftcontroller.SendHapticImpulse(0.5f, 0.5f);    
}

    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnTriggerStay(Collider other) 
    {
         Debug.Log("Cube touched by the Player!");
       // OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        leftcontroller.SendHapticImpulse(0.5f, 0.5f);
        
    }


//    
//     }
 }
