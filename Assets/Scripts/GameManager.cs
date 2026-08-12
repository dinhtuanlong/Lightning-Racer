using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformSpawner;
    bool gameOver = false;

    void Awake()
    {
        // GameManager gameManager = FindAnyObjectByType<GameManager>();
        if (instance == null)
        {
            instance = this;
        } 
        // else
        // {
        //     Destroy(this);
        // }
    }

    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0) && !gameOver)
        {
            GameStart();
        }
    }

    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
    }

    public void GameOver()
    {
        gameStarted = false;
        gameOver = true;
        platformSpawner.SetActive(false);
        Invoke("ReloadLevel", 2f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
