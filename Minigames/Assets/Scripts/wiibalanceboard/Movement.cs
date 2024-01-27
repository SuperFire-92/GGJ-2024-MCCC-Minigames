//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float turnSpeed;
    public float timer;
    public float randomPushSpeed;

    private Rigidbody2D rb;

    private float timerStartTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timerStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timerStartTime > timer)
        {
            timerStartTime = Time.time;
            ruinTheFun();
        }

        moveHorizontal();
    }

    void moveHorizontal()
    {
        rb.angularVelocity -= Input.GetAxisRaw("Horizontal") * Time.deltaTime * turnSpeed;
    }

    void ruinTheFun()
    {
        rb.angularVelocity += randomPushSpeed * Random.Range(-1.0f, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            //Die
            Debug.Log("you dead");
        }
    }

}
