using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            Move();
        }
    }
    void Move()
    {
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * input, rb.velocity.y);
    }
    
}
