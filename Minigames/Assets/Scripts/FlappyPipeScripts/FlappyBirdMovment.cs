using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlappyBirdMovment : MonoBehaviour
{
    public float speed;
    public float jumpStrength;
    public float timerDuration;

    private float timerStart;

    private Rigidbody2D rb;
    private float realJumpStrength;
    private float realMinVelocity;
    public float minVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timerStart = Time.time - timerDuration;
        realJumpStrength = (Random.Range(2.5f, jumpStrength) + Random.Range(2.5f, jumpStrength)) / 2f;
        realMinVelocity = (Random.Range(minVelocity, 2.5f) + Random.Range(minVelocity, 2.5f)) / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);

        if (Time.time - timerStart > timerDuration && rb.velocity.y <= realMinVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.velocity += Vector2.up * realJumpStrength;
            timerStart = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jumpStrength;
        }

        float angle = Vector3.Angle(Vector3.right, rb.velocity);
        if (rb.velocity.y > 0)
        {
            angle = -angle;
        }
        transform.eulerAngles = new Vector3(0, 0, angle);

    }
}
