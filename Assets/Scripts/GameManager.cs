using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject blackOut;

    //starts to spawn only when user jumps on the arena
    public bool gameStarted { get; set; }
    public bool eventHappening { get; set; }
    public int drinkCount { get; set; }
    public int paddleCount { get; set; }


    void Awake()
    {
        gameStarted = false;
        drinkCount = 0;
        paddleCount = 0;
        eventHappening = false;

        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {

        if (drinkCount == 5)
        {
            BlackOut();
        }
    }

    public void BlackOut()
    {
        blackOut.SetActive(true);
        GetComponent<AudioSource>().Play();
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
        SceneManager.LoadScene("MainGameScene");
    }
}
