using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class OriginBugFix : MonoBehaviour
{
    private bool oneTimer = true; 
    private float rotationSpeed = 100.0f;
    public InputActionReference rotationAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (oneTimer == true)
        {
            oneTimer = false;
            rotationAction.action.Enable();
            Vector2 inputRotation = rotationAction.action.ReadValue<Vector2>();
            float rotationAmount = inputRotation.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotationAmount);

        }
        
    }
}
