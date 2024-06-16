using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject EndPoint;
    public AudioSource src;
    public float speed = 1.0f; // Movement speed
    private bool isMoving = false;

    void Start()
    {
        // Optional: Set the initial position of the GameObject to the start point

        transform.position = StartPoint.transform.position;
        isMoving = true; // Start moving immediately
        src.PlayOneShot(src.clip);
    }

    void Update()
    {
        if (this.gameObject.activeSelf && isMoving)
        {
            // Move the object towards the end point
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, speed * Time.deltaTime);

            // Check if the object has reached the end point
            if (Vector3.Distance(transform.position, EndPoint.transform.position) < 0.001f)
            {
                isMoving = false; // Stop moving
                this.gameObject.SetActive(false);
                GameManager.instance.eventHappening = false;

                // Optional: Trigger any actions you want to perform when the object reaches the end point
            }
        }
    }
}
