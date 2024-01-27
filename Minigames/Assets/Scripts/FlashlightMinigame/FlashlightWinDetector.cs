using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightWinDetector : MonoBehaviour
{
    [SerializeField] private GameObject findMe;

    [SerializeField] private float timeToPass;
    private float timeHovering;
    bool win;

    void Start()
    {
        timeHovering = 0f;
        win = false;
    }

    void Update()
    {
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
}
