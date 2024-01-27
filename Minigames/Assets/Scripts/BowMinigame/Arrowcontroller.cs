using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Arrowcontroller : MonoBehaviour
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
        Move();
    }
    void Move()
    {
        rb.velocity = new Vector2(speed * (float)1.5, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Endpoint"))
        {
            Destroy(this.gameObject);
            GameManager.endMiniGame(true);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
            GameManager.endMiniGame(false);
        }
    }
}
