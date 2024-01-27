using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private GameObject findMe;
    private int xMax;
    private int yMax;

    [SerializeField] private float timeToPass;
    private float timeHovering;
    bool win;

    void Start()
    {
        xMax = Screen.width;
        yMax = Screen.height;
        timeHovering = 0f;
        win = false;
    }

    void Update()
    {
        followMouse();
        win = foundIt();
        if (win)
        {
            GameManager.endMiniGame(true);
        }
    }


    private bool foundIt()
    {
        float xDist = findMe.transform.position.x - transform.position.x;
        float yDist = findMe.transform.position.y - transform.position.y;

        if (xDist < -0.5f || xDist > 0.5f)
        {
            return false;
        }
        if (yDist < -0.5f || yDist > 0.5f)
        {
            return false;
        }

        timeHovering += Time.deltaTime;
        if (timeHovering > timeToPass)
        {
            win = true;
        }

        return win;
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