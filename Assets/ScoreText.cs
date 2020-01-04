using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    int score;
    Text text;
    public void Start()
    {
        score = 0;
        text = GetComponent<Text>();
        text.text = score.ToString();
    }
    public void IncrementScore()
    {
        score += 1;
        text.text = score.ToString();
    }
}
