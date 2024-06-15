using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnv : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    //public Vector3 direction = Vector3.forward; // Direction of movement
   public GameObject CoastObjects;
    private float movementSpeed = 0.03f; // Speed of movement

    void Update()
    {
        // Move the GameObject slowly in the specified direction
        //this.gameObject.transform.Translate(direction * speed * Time.deltaTime);
        CoastObjects.transform.position += Vector3.right * movementSpeed * Time.deltaTime;
    }
}
