using UnityEngine;

public class LookAtReference : MonoBehaviour
{
    // Reference point to look at
    public Transform referencePoint;

    void Update()
    {
        // Check if the reference point is assigned
        if (referencePoint != null)
        {
            // Make the GameObject look at the reference point
            transform.LookAt(referencePoint);
        }
    }
}
