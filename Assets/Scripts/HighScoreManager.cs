using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static int HighScore = 0;
    public static TMPro.TMP_Text highScoreText;
    public int CurrentScore;
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        CurrentScore = (int)PlayerManager.numberOfCoins;
        if (CurrentScore > HighScore)
        {
            HighScore = (int)PlayerManager.numberOfCoins;
        }
    }
}

