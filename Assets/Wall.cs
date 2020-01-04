using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    BoxCollider2D boxCollider;
    public static float height = 1f;
    public void Init(float screenWidth, float y)
    {
        // center of screen
        transform.position = new Vector2(0, y);

        boxCollider = GetComponent<BoxCollider2D>() as BoxCollider2D;
        // wide as screen
        boxCollider.size = new Vector2(screenWidth, height);
    }
}
