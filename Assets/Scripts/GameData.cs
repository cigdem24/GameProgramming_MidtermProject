using Unity.Collections;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int Score;
    public int NewBest;
    public float PlayerX;
    public float PlayerY;


    public GameData(float playerPositionX, float playerPositionY)
    {

        PlayerX = playerPositionX;
        PlayerY = playerPositionY;

    }


    public GameData(int score, int newBest)
    {
        NewBest = newBest;
        Score = score;
    }



}
