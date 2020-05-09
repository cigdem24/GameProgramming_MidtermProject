using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class BallController : MonoBehaviour
{
    public Text scoreTxt, newBestTxt;
    public int Score { get; private set; }
    public int NewBest { get; private set; }

    Rigidbody2D ballrigidbody;

    public float moveSpeed = 30;

    public Transform player,ball;
  
 
    void Start()
    {
        Load();
     
        ballrigidbody = gameObject.GetComponent<Rigidbody2D>(); //Topun rigibody bileşen değerini al ve ballrigidbody ye ata.
        ballrigidbody.velocity = new Vector2(1, 0) * moveSpeed;
    }

    //ESC ile Menüye dönme metodu
    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("BOMBA"))
        {
            Destroy(collision.gameObject, 0f);
            makeScore();
        }
        else if(collision.gameObject.tag.Equals("SAGDUVAR") || collision.gameObject.tag.Equals("SOLDUVAR") || collision.gameObject.tag.Equals("OYUNCU"))
        {
            GetComponent<AudioSource>().Play();
        }
      
    }
    public void makeScore()
    {
        Score++;
        scoreTxt.text = Score.ToString();
        SaveScores();
        goUptairs();

        if (Score > NewBest)
        {
            NewBest = Score;
            newBestTxt.text = NewBest.ToString();
            
        }
       
    }

    private void goUptairs()
    {
        if (Score % 5 == 0)
        {   
            player.transform.Translate(new Vector2(0, 1));
            
        }
        float distance = Vector2.Distance(ball.transform.position, player.transform.position);
        if (distance < 1.5f)
        {
            player.transform.position = new Vector2(0.02f, -4.4f);
            
        }
        SavePlayerPosition();
    }

    private void SaveScores()
    {
        SaveLoadManager.SaveScores(Score,NewBest);
    }
    private void SavePlayerPosition()
    {
        SaveLoadManager.SavePlayerPosition(player.position.x, player.position.y);
    }
  
    private void Load()
    {   
        //Score ve High Score Yükle 
        GameData data = SaveLoadManager.LoadScores();
        NewBest = data.NewBest;
        Score = data.Score;
        scoreTxt.text = Score.ToString();
        newBestTxt.text = NewBest.ToString();

        //Player'in pozisyonunu Yükle
        GameData data1 = SaveLoadManager.LoadPlayerPosition();
        player.position = new Vector2(data1.PlayerX, data1.PlayerY);  
    }
}
