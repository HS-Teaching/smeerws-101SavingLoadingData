using UnityEngine;
using GameDevProfi.Utils;
using System.IO;

[System.Serializable] //Mark that this class is able to read/write data
public class SaveGameData
{
    //all member (instance) variables will be saved;
    public float highscore = -1f; //declare and inizialize (with default value) variable highscore
    //public int test;

    private static string GetFilename()
    {
        //Path.DirectorySeparatorCha --> / Linux/Mac, \ Windwos
        return Application.persistentDataPath + Path.DirectorySeparatorChar + "savegame.xml";
    }

    //Speichert Spielstand
    public void Save()
    {
        Debug.Log("Save Data: " + GetFilename());

        HighScoreController highscoreController = Component.FindObjectOfType<HighScoreController>(); //returns first GameObject HighScoreController in scene 
        highscore = highscoreController.GetHighScore(); // gets the current highscore saved in the HighscoreController GameObject
        highscoreController.setFilenameMSG("save",GetFilename());

        // test = 123;
        string xml = XML.Save(this); //takes the XML Class --> using GameDevProfi.Utils
        File.WriteAllText(GetFilename(), xml);
        Debug.Log(xml);
    }

    //Lädt Spielstand
    public static SaveGameData Load()
    {
        Debug.Log("Load Data: " + GetFilename());

        SaveGameData save = XML.Load<SaveGameData>(File.ReadAllText(GetFilename()));
        HighScoreController highscoreController = Component.FindObjectOfType<HighScoreController>();
        highscoreController.SetHighScore(save.highscore);
        highscoreController.setFilenameMSG("load", GetFilename());

        return save;
    }

}
