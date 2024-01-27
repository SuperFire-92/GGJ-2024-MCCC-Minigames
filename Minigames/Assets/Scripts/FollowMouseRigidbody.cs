using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRigidbody : MonoBehaviour
{
    private int xMax;
    private int yMax;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xMax = Screen.width;
        yMax = Screen.height;
    }

    void Update()
    {
        followMouse();
    }
    private void followMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.x /= xMax;
        mousePos.y /= yMax;

        mousePos = Camera.main.ViewportToWorldPoint(mousePos);
        mousePos.z = 0;

        rb.MovePosition(mousePos);
    }
}
