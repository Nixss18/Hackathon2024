using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnv : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    //public Vector3 direction = Vector3.forward; // Direction of movement
    public GameObject Ship;
    private float maxDistance = 27f;
    private float movementSpeed = 0.035f; // Speed of movement
    private Vector3 startPosition;

    bool goesBackwards = true;


    void Start()
    {
        // Store the initial position of the object
        startPosition = Ship.transform.position;
        //movementSpeed = defaultSpeed;
        
    }


    void Update()
    {
        // Move the GameObject slowly in the specified direction
        //this.gameObject.transform.Translate(direction * speed * Time.deltaTime);
       
        if (goesBackwards == true)
        {
            if (Vector3.Distance(startPosition, Ship.transform.position) <= maxDistance)
            {
                Ship.transform.position += Vector3.right * movementSpeed * Time.deltaTime;
                Debug.Log(Vector3.Distance(startPosition, Ship.transform.position) + "t"); 
                // Reset the object's position to the starting position
            // Ship.transform.position = startPosition;
            }
            else
            {
                goesBackwards = false;
            }
        }
        else
        {
            if (Vector3.Distance(startPosition, Ship.transform.position) >= 0.5)
            {
                Ship.transform.position += Vector3.right * -movementSpeed * Time.deltaTime;
                Debug.Log(Vector3.Distance(startPosition, Ship.transform.position)  + "F"); 
                // Reset the object's position to the starting position
            // Ship.transform.position = startPosition;
            }
            else
            {
                goesBackwards = true;
            }
        }

        // if (Vector3.Distance(startPosition, Ship.transform.position) <= maxDistance)
        // {
        //     Ship.transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        //     Debug.Log(Vector3.Distance(startPosition, Ship.transform.position)); 
        //     // Reset the object's position to the starting position
        //    // Ship.transform.position = startPosition;
        // }
        


        
    }
}
