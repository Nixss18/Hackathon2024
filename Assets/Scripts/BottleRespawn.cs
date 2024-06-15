using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRespawn : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    private Quaternion startRot;
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -3)
        {
            transform.position = startPos.position;
            transform.rotation = startRot;
        }
    }
}
