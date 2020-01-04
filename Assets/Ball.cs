using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float initSpeed = 10f, waitTime = 2f, speed;
    Vector2 direction;
    int[] angles;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        angles = new int[8]{45, 75, 105, 135, -45, -75, -105, -135};
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        speed = initSpeed;
        transform.position = new Vector2(0, 0);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(waitTime);
        direction = Quaternion.AngleAxis(angles[Random.Range(0, 8)], Vector3.forward) * Vector3.up.normalized;
        rb.velocity = direction * speed * Time.deltaTime * GameManager.frameRate;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Paddle") {
            speed += 1;
            float velY = rb.velocity.y / 3 + other.rigidbody.velocity.y / 2;
            if (Mathf.Abs(velY) < speed)
            {
                velY = speed * Mathf.Sign(velY);
            }
            float velX = rb.velocity.x;
            if (Mathf.Abs(velX) < speed)
            {
                velX = speed * Mathf.Sign(velX);
            }
            rb.velocity = new Vector2(velX, velY);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            StopCoroutine(Reset());
            StartCoroutine(Reset());
        }
    }
}
