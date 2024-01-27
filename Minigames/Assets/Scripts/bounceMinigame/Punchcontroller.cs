using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punchcontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Punch();
    }
    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * (float)1.15);
        }
    }
}
