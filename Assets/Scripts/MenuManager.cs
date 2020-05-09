using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameData game;


   //NewGame butonuna basıldığında çalışacak method
    public void New()
    {
            game = SaveLoadManager.LoadScores();
            game.Score = 0; 
            game.PlayerX =  0f;
            game.PlayerY =  -4.4f;  
            SaveLoadManager.SaveScores(game.Score, game.NewBest);
            SaveLoadManager.SavePlayerPosition(game.PlayerX, game.PlayerY);
            SceneManager.LoadScene(1);
   
    }

    //LoadLastGame butonuna basıldığında çalışacak method
    public void Last()
    {
        SceneManager.LoadScene(1);
    }


}
