using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager 
{
    //Score
    public static void SaveScores(int score, int newBest)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.savefile";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData gamedata = new GameData(score, newBest);
        formatter.Serialize(stream, gamedata); 
        stream.Close();
    }
    public static GameData LoadScores()
    {
        string path = Application.persistentDataPath + "/score.savefile";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData gamedata = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gamedata;
        }
        else
        {
            return null;
        }
    }
   
    //Player Position

    public static void SavePlayerPosition(float positionX, float positionY)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.save";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData gamedata = new GameData (positionX, positionY);
        formatter.Serialize(stream, gamedata);
        stream.Close();
    }
    public static GameData LoadPlayerPosition()
    {
        string path = Application.persistentDataPath + "/score.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData gamedata = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gamedata;
        }
        else
        {
            return null;
        }
    }

}
