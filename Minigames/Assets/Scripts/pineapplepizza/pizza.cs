using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza : MonoBehaviour
{
    public float rotationSpeed;
    private Rigidbody2D rb;

    private float windup;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        windup = 0.00f;
    }

    // Update is called once per frame
    void Update()
    {
        windup -= Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;

        //transform.localEulerAngles = new Vector3(0.00f, 0.00f, convertAngles(windup));

        rb.MoveRotation(windup);
    }

    private float convertAngles(float degrees)
    {
        return ((degrees + 180.00f) % 360.00f) - 180.00f;
    }
}
