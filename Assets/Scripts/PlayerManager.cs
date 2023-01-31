using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject gameStartPanel;
    public TMPro.TMP_Text highScoreText;

    public static float numberOfCoins;
    public TMPro.TMP_Text coinsText;
    public GameObject startingText;

    public static bool isGameStarted;
    void Start()
    {
        highScoreText.text = "Highscore: "+ HighScoreManager.HighScore;
        gameOver = false;
        gameStartPanel.SetActive(true);
        isGameStarted = false;
        numberOfCoins = 0;
        HighScoreManager.highScoreText = highScoreText;
    }
    void Update()
    {
        if (gameOver == true)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        coinsText.text = "Coins: " + (int)numberOfCoins;

        if (Input.GetMouseButtonDown(0))
        {
            isGameStarted = true;
            gameStartPanel.SetActive(false);
        }

        if(isGameStarted == true)
        {
            numberOfCoins += 5 * Time.deltaTime;
        }
    }
}
