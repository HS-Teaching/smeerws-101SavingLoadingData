using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public static HighScoreController instance;

    public Text text;

    float highScore = 0; 

    //Singelton Pattern
    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("CREATE INSTANCE");
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private float GetRandomHighscore()
    {
        Debug.Log("Button Do Something");
        return Random.Range(0f, 1000f);
    }

    public float GetHighScore()
    {
        return highScore;
    }

    public void SetHighScore(float val)
    {
        highScore = val;
    }

    public void ResetHighScore()
    {
        highScore = 0;
        text.text = highScore.ToString();
    }

    public void SetDisplayRandomScore()
    {
        Debug.Log("Generate Random Highscore");
        highScore = GetRandomHighscore();

        Debug.Log("Set Text");
        text.text = highScore.ToString();

        SaveGameData saveGameData = new SaveGameData();
        saveGameData.Save();
    }

    public void LoadHighScore()
    {
        SaveGameData.Load();
        text.text = highScore.ToString();
    }

}
