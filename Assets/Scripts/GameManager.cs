using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //starts to spawn only when user jumps on the arena
    public bool gameStarted { get; set; }
    public int drinkCount { get; set; }
    public int paddleCount { get; set; }

    void Awake()
    {
        gameStarted = false;
        drinkCount = 0;
        paddleCount = 0;
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void BlackOut()
    {
        StartCoroutine(RestartRoutine());
    }

    IEnumerator RestartRoutine()
    {
        yield return new WaitForSeconds(3f);
        RestartGame();

    }

    void RestartGame()
    {
        //set a black screen and then restart the scene
        //SceneManager.GetActiveScene().name
        SceneManager.LoadScene("MainMenu");
    }
}
