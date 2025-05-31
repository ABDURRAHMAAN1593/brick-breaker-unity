using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Ball ball{get; private set;}
    public Paddle1 paddle{get; private set;}
    public Bricks1[] bricks{get; private set;}
    public int score = 0;
    public int lives = 5;
    public int level = 1;
    public int i;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 5;

        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle1>();
        this.bricks = FindObjectsOfType<Bricks1>();
    }

    public void Miss()
    {
        this.lives--;

        if (this.lives>0)
        {
             ResetLevel(); 
        }

        else
        {
            GameOver();
        }
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();

        // for (int i = 0; i < this.bricks.Length; i++)
        // {
        //      this.bricks[i].ResetBrick();
        // }
    }

    private void GameOver()
    {
        NewGame();
    }


    public void Hit(Bricks1 bricks)
    {
        this.score += bricks.points;
    }

    // public void Hit(Bricks bricks)
    // {
    //     this.score += bricks.points;

    //     if (Cleared())
    //     {
    //         LoadLevel(this.level + 1);
    //     }
    // }

    // private bool Cleared()
    // {
    //     for (i=0; i<this.bricks.Length; i++)
    //     {
    //         if(this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
    //         {
    //             return false;
    //         }
    //     }

    //     return true;
    // }
}
