using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;
    public static Vector2 bottomLeft, topRight;
    public Wall wall;
    public Goal goal;
    RectTransform canvas;
    public ScoreText scoreText;
    private int timescale;
    public const int frameRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        timescale = 1;

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        float screenWidth = topRight.x - bottomLeft.x;
        float screenHeight = topRight.y - bottomLeft.y;

        // create ball in middle of screen
        Instantiate(ball);

        // create player 1 and 2, player 1 at left and player 2 at right
        Paddle p1 = Instantiate(paddle) as Paddle;
        Paddle p2 = Instantiate(paddle) as Paddle;
        p1.Init(bottomLeft.x + p1.transform.localScale.x, "Vertical1");
        p2.Init(topRight.x - p2.transform.localScale.x, "Vertical2");

        // create top and bottom walls to bounce ball off of
        Wall topWall = Instantiate(wall) as Wall;
        Wall bottomWall = Instantiate(wall) as Wall;
        topWall.Init(screenWidth, topRight.y + Wall.height / 2);
        bottomWall.Init(screenWidth, bottomLeft.y - Wall.height / 2);

        // create score text for each player - player 1 at left and player 2 at right
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<RectTransform>();
        ScoreText scoreText1 = Instantiate(scoreText, new Vector2(bottomLeft.x + screenWidth / 4f, 
                                            topRight.y - screenHeight / 10f), 
                                            Quaternion.identity, canvas.transform);
        ScoreText scoreText2 = Instantiate(scoreText, new Vector2(topRight.x - screenWidth / 4f,
                                            topRight.y - screenHeight / 10f), 
                                            Quaternion.identity, canvas.transform);
        
        // create goals for each player to score in, goal 1 at right and goal 2 at left
        Goal goal1 = Instantiate(goal) as Goal;
        Goal goal2 = Instantiate(goal) as Goal;
        // link text and goals together to update scores on ball trigger
        goal1.Init(topRight.x, screenHeight, scoreText1);
        goal2.Init(bottomLeft.x, screenHeight, scoreText2);
    }
    public void Restart()
    {
        print("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause()
    {
        print("Pause");
        timescale ^= 1;
        Time.timeScale = timescale;
    }
}
