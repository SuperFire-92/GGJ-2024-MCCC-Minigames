using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowcontroller : MonoBehaviour
{
    private float startpos;
    private Rigidbody2D rb;
    public GameObject Arrow;
    public Transform Shootpoint;
    public float speed;
    private bool hasfire;
    private bool goingup;
    void Start()
    {

        startpos = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        goingup = true;
    }

    // Update is called once per frame
    void Update()
    {

        Moveup();
        MoveDown();
        if(speed > 25)
        {
            speed = 15;
        }
        if (hasfire == false)
        {
            shoot();
        }
    }
    void Moveup()
    {
        if (transform.position.y <= startpos + 4 && goingup)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * (float)1.5);

        }
        if (transform.position.y >= startpos + 4)
        {
            goingup = false;
            speed = speed + (float).1;
            //Debug.Log("Switch down");
        }

    }
    void MoveDown()
    {
        if (transform.position.y >= startpos - 4 && goingup == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * -(float)1.5);

        }
        if (transform.position.y <= startpos - 4)
        {
            goingup = true;
            speed = speed + (float).1;
            //Debug.Log("Switch up");
        }
    }

    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Arrow, Shootpoint.transform.position, Shootpoint.transform.rotation);
            hasfire = true;
        }
    }
}
