using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowcontroller : MonoBehaviour
{
    private float yStartPos;
    private Rigidbody2D rb;
    public GameObject Arrow;
    public Transform Shootpoint;
    public float speed;
    private bool hasfire;
    private bool goingup;
    void Start()
    {

        yStartPos = transform.position.y;
        goingup = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveBow();
        if (hasfire == false)
        {
            shoot();
        }
    }

    private void moveBow()
    {
        if (goingup == true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y > yStartPos + 4)
            {
                goingup = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y < yStartPos - 4)
            {
                goingup = true;
            }
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
