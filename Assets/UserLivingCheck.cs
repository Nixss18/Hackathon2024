using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserLivingCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.y < -1f) 
        {
            GameManager.instance.drinkCount = 5;

        }
    }
}
