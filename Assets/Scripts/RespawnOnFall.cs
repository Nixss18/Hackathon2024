using UnityEngine;

public class RespawnOnFall : MonoBehaviour
{
    // Initial position of the object
    private Vector3 startPosition;
    private Quaternion startRotation;

    public GameObject shipReference; 

    void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the object's y position is less than -3
        if (transform.position.y <= -3f)
        {
            // Reset the object's position to the starting position
            transform.position = shipReference.transform.position;
            transform.rotation = shipReference.transform.rotation;
            
        }
    }
}
