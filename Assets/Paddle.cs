using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody2D rb;
    string axis;

    // Start is called before the first frame update
    void Start()
    {
        speed = 30;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(float x, string axis)
    {
        transform.position = new Vector2(x, 0);
        this.axis = axis;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis(axis) * speed;
        rb.velocity = Vector2.up * move * Time.deltaTime * GameManager.frameRate;
    }
}
