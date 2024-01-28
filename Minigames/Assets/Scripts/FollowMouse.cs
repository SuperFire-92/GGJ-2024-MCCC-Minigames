using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class FollowMouse : MonoBehaviour
{
    private int xMax;
    private int yMax;

    void Start()
    {
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

        transform.position = mousePos;
    }
}