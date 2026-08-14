using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformSpawner;
    public TextMeshProUGUI text;
    public TextMeshProUGUI bestScoreText;
    public GameObject gameplayUI;
    public GameObject menuUI;
    public AudioClip[] gameMusic;
    bool gameOver = false;
    int score = 0;
    int highScore = 0;
    Coroutine scoreCoroutine;
    AudioSource audioSource;
    string HIGH_SCORE_STRING = "HighScore";

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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_STRING);
        bestScoreText.text = "Best score: " + highScore;
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
        scoreCoroutine = StartCoroutine(UpdateScore());
        gameplayUI.SetActive(true);
        menuUI.SetActive(false);
        audioSource.clip = gameMusic[1];
        audioSource.Play();
    }

    public void GameOver()
    {
        gameStarted = false;
        gameOver = true;
        platformSpawner.SetActive(false);
        SaveHighScore();
        StopCoroutine(scoreCoroutine);
        Invoke("ReloadLevel", 2f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            text.text = score.ToString();
        }
    }

    public void DiamondIncrementScore()
    {
        score += 5;
        text.text = score.ToString();
        audioSource.PlayOneShot(gameMusic[2], .9f);
    }

    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey(HIGH_SCORE_STRING))
        {
            // Update high score
            if (score > PlayerPrefs.GetInt(HIGH_SCORE_STRING))
            {
                PlayerPrefs.SetInt(HIGH_SCORE_STRING, score);
            }
        } else
        {
            // Playing the first time
            PlayerPrefs.SetInt(HIGH_SCORE_STRING, score);
        }
    }
}
