using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public static HighScoreController instance;

    public Text scoreText;
    public Text filenameText;

    float highScore = 0;
    string filenameMSG = "";

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
        scoreText.text = highScore.ToString();
    }


    public void setFilenameMSG(string saveOrload, string filename)
    {
        if(saveOrload == "save")
        {
            filenameMSG = "save to: " + filename;
        }
        else if(saveOrload == "load")
        {
            filenameMSG = "load from " + filename;
        }
    }

    public void SetDisplayRandomScore()
    {
        Debug.Log("Generate Random Highscore");
        highScore = GetRandomHighscore();

        Debug.Log("Set Text");
        scoreText.text = highScore.ToString();

        SaveGameData saveGameData = new SaveGameData();
        saveGameData.Save();
        filenameText.text = filenameMSG;
    }

    public void LoadHighScore()
    {
        SaveGameData.Load();
        scoreText.text = highScore.ToString();
        filenameText.text = filenameMSG;
    }

}
