using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    BoxCollider2D boxCollider;
    ScoreText scoreText;
    
    public void Init(float x, float screenHeight, ScoreText st)
    {
        // center of screen
        transform.position = new Vector2(x, 0);

        boxCollider = GetComponent<BoxCollider2D>() as BoxCollider2D;
        // wide as screen
        boxCollider.size = new Vector2(0.1f, screenHeight);
        scoreText = st;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball") 
        {
            scoreText.IncrementScore();
        }
    }
}
