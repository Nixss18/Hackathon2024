using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //starts to spawn only when user jumps on the arena
    public bool gameStarted { get; set; }
    public int drinkCount { get; set; }

    void Awake()
    {
        gameStarted = false;
        drinkCount = 3;
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}
